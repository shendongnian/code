    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ReadXml()
        {
            XDocument xdocument = XDocument.Load(Server.MapPath("People.xml"));
            var persons = from person in xdocument.Descendants("Person")
                          select new
                          {
                              Name = person.Element("Name").Value,
                              City = person.Element("City").Value,
                              Age = person.Element("Age").Value
                          };
            litResults.Text = "";
            foreach (var person in persons)
            {
                litResults.Text = litResults.Text + "Name: " + person.Name + "<br/>";
                litResults.Text = litResults.Text + "City: " + person.City + "<br/>";
                litResults.Text = litResults.Text + "Age: " + person.Age + "<br/><br/>";
            }
            if (litResults.Text == "")
                litResults.Text = "No Results...";
        }
        protected void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtCity.Text == "" || txtAge.Text == "")
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Please Complete the form";
                }
                else
                {
                    XDocument xdocumnet = XDocument.Load(Server.MapPath("People.xml"));
                    xdocumnet.Element("Persons").Add(new XElement("Person",
                        new XElement("Name", txtName.Text),
                        new XElement("City", txtCity.Text),
                        new XElement("Age", txtAge.Text)));
                    xdocumnet.Save(Server.MapPath("People.xml"));
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Data Successfully loaded to xml file";
                    txtName.Text = "";
                    txtCity.Text = "";
                    txtAge.Text = "";
                    ReadXml();
                }
            }
            catch
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Sorry unable to precess request.Please try again";
            }
        }
        protected void butRead_Click(object sender, EventArgs e)
        {
            ReadXml();
            lblStatus.Text = "";
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtCity.Text == "" || txtAge.Text == "")
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Please enter all details in the form";
                }
                else
                {
                    XDocument xdocument = XDocument.Load(Server.MapPath("People.xml"));
                    var persondata = (from person in xdocument.Descendants("Person")
                                      where person.Element("Name").Value.Equals(txtName.Text)
                                      select person).Single();
                    persondata.Element("City").Value = txtCity.Text;
                    persondata.Element("Age").Value = txtAge.Text;
                    xdocument.Save(Server.MapPath("People.xml"));
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "The data updated successfully";
                    ReadXml();
                }
            }
            catch(Exception ex)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = ex.Message;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Please enter the name of the person to delete...";                    
                }
                else
                {
                    XDocument xdocument = XDocument.Load(Server.MapPath("People.xml"));
                    var persondata = (from person in xdocument.Descendants("Person")
                                      where person.Element("Name").Value.Equals(txtName.Text)
                                      select person).Single();
                    persondata.Remove();
                    xdocument.Save(Server.MapPath("People.xml"));
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "The data deleted successfully...";
                    txtName.Text = "";
                    txtCity.Text = "";
                    txtAge.Text = "";
                    ReadXml();
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = ex.Message;
            }
        }
    }
}
