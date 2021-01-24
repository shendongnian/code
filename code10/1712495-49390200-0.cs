        public XeroTransferResult CreateInvoices(IEnumerable<InvoiceModel> invoices, string user, string status)
        {
            _user = XeroApiHelper.User(user);
            var invoicestatus = InvoiceStatus.Draft;
            if (status == "SUBMITTED")
            {
                invoicestatus = InvoiceStatus.Submitted;
            }
            else if (status == "AUTHORISED")
            {
                invoicestatus = InvoiceStatus.Authorised;
            }
            var api = XeroApiHelper.CoreApi();
            var xinvs = new List<Invoice>();
            foreach (var inv in invoices)
            {
                var items = new List<LineItem>();
                foreach (var line in inv.Lines)
                {
                    decimal discount = 0;
                    if (line.PriceBeforeDiscount != line.Price)
                    {
                        discount = (decimal)(1 - line.Price / line.PriceBeforeDiscount) * 100;
                    }
                    items.Add(new LineItem
                    {
                        AccountCode = line.AccountCode,
                        Description = line.PublicationName != "N/A" ? line.PublicationName + " - " + line.Description : line.Description,
                        TaxAmount = (decimal)line.TaxAmount,
                        Quantity = 1,
                        UnitAmount = (decimal)line.PriceBeforeDiscount,
                        DiscountRate = discount,
                        TaxType = line.XeroCode,
                        ItemCode = line.ItemCode
                    });
                }
                var person = inv.Company.People.FirstOrDefault(p => p.IsAccountContact);
                if (person == null)
                {
                    person = inv.Company.People.FirstOrDefault(p => p.IsPrimaryContact);
                }
                var ninv = new Invoice
                {
                    Number = inv.ClientInvoiceId,
                    Type = InvoiceType.AccountsReceivable,
                    Status = invoicestatus,
                    Reference = inv.Reference,
                    Contact = new Contact
                    {
                        Name = inv.Company.OrganisationName,
                        //ContactNumber = "MM" + inv.Company.CompanyId.ToString(),
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        EmailAddress = person.Email,
                        Phones = new List<Phone>()
                        {
                            new Phone {PhoneNumber = person.Telephone, PhoneType = PhoneType.Default},
                            new Phone {PhoneNumber = person.Mobile, PhoneType = PhoneType.Mobile}
                        },
                        Addresses = new List<Address>
                        { new Address
                            {
                            //AttentionTo = inv.Company.People.FirstOrDefault(p => p.IsAccountContact) == null 
                            //? inv.Company.People.FirstOrDefault(p=> p.IsPrimaryContact).FullName
                            //: inv.Company.People.FirstOrDefault(p => p.IsAccountContact).FullName,
                                //AddressLine1 = inv.Company.OrganisationName,
                                AddressLine1 = inv.Company.Address.Address1,
                                AddressLine2 = inv.Company.Address.Address2 ?? "",
                                AddressLine3 = inv.Company.Address.Address3 ?? "",
                                Region = inv.Company.Address.CountyState,
                                City = inv.Company.Address.TownCity,
                                PostalCode = inv.Company.Address.PostCode,
                            }
                        }
                    },
                    AmountDue = (decimal)inv.TotalAmount,
                    Date = inv.InvoiceDate,
                    DueDate = inv.DueDate,
                    LineItems = items,
                    LineAmountTypes = LineAmountType.Exclusive
                };
                if (SessionContext.TransferContactDetailsToXero == false)
                {
                    ninv.Contact = new Contact
                    {
                        Id = inv.Company.XeroId ?? Guid.Empty,
                        Name = inv.Company.OrganisationName
                    };
                }
                xinvs.Add(ninv);
            }
            var success = true;
            var xinvresult = new List<Invoice>();
            try
            {
                api.SummarizeErrors(false);
                xinvresult = api.Invoices.Create(xinvs).ToList();
            }
            catch (ValidationException ex)
            {
                  // Something's gone wrong
            }
            foreach (var inv in xinvresult)
            {
                var mminvoice = invoices.FirstOrDefault(i => i.ClientInvoiceId == inv.Number);
                if (inv.Errors != null && inv.Errors.Count > 0)
                {
                    success = false;
                    if (mminvoice != null)
                    {
                        var errors = new List<XeroError>();
                        foreach (var err in inv.Errors)
                        {
                            errors.Add(new XeroError { ErrorDescription = err.Message });
                        }
                        mminvoice.XeroErrors = errors;
                    }
                }
                else
                {
                    mminvoice.XeroTransferDate = DateTime.Now;
                    mminvoice.XeroId = inv.Id;
                    mminvoice.XeroErrors = new List<XeroError>();
                }
            }
            return new XeroTransferResult
            {
                Invoices = invoices,
                Success = success
            };
        }
