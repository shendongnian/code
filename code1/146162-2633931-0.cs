    var query = from c in db.Descendants("Customer")
                                select new
                                {
                                    CustomerNumber = Convert.ToInt32((string)c.Element("CustomerNumber").Value),
                                    Name = (string)c.Element("Name").Value,
                                    Address = (string)c.Element("Address").Value,
                                    Postcode = (string)c.Element("PostCode1").Value + " " + c.Element("PostCode2").Value
                                };
                    dgvEditCusts.DataSource = query.ToList();
