        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtZip.Text != "" && txtAdd1.Text != "" && txtCity.Text != "")
            {
                TestDataClassDataContext dc = new TestDataClassDataContext();
                Address addr = new Address()
                {
                    AddressLine1 = txtAdd1.Text,
                    AddressLine2 = txtAdd2.Text,
                    City = txtCity.Text,
                    PostalCode = txtZip.Text,
                    StateProvinceID = Convert.ToInt32(ddlState.SelectedValue)
                };
                dc.Addresses.InsertOnSubmit(addr);
                dc.SubmitChanges();
                int nAddID = addr.AddressID;
                EmployeeAddress empadd = new EmployeeAddress()
                {
                    EmployeeID = Convert.ToInt32(_curEmpID),
                    AddressID = nAddID
                };
                dc.EmployeeAddresses.InsertOnSubmit(empadd);
                dc.SubmitChanges();
                lblSuccess.Visible = true;
                lblErrMsg.Visible = false;
                SetAddrList();
            }
            else
            {
                lblErrMsg.Text = "Invalid Input";
                lblErrMsg.Visible = true;
            }
        }
