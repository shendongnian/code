    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    namespace TestProj
    {
    public partial class Search : System.Web.UI.Page
    {
        
        static IQueryable<Contact> _conResults;
        //static IQueryable<EmpContact> _empResults;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void ddlSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdvCust.DataSource = null;
            gdvCust.DataBind();
            gdvEmp.DataSource = null;
            gdvEmp.DataBind();
            bool flag;
            if (ddlSelector.SelectedValue == "Employee")
                flag = true;
            else
            {               
                flag = false;
            }
            foreach( Control c in empCriteria.Controls)
            {
                c.Visible = flag;
            }
        }
        private IQueryable<Contact> CreateCustQuery()
        {
           TestDataClassDataContext dc = new TestDataClassDataContext();
            var predicate = PredicateBuilder.True<Contact>();
            var cust = from individual in dc.Individuals
                      join contact in dc.Contacts on individual.ContactID equals contact.ContactID
                      select contact;
            if (!string.IsNullOrEmpty(txtLname.Text))
                predicate = predicate.And( e => e.LastName.Contains(txtLname.Text));
            if (!string.IsNullOrEmpty(txtFname.Text))
                predicate = predicate.And(e => e.FirstName.Contains(txtFname.Text));
            if (!string.IsNullOrEmpty(txtMname.Text))
                predicate = predicate.And(e => e.MiddleName.Contains(txtMname.Text));
            if (Utility.IsValidPhone(txtPhone.Text))
                predicate = predicate.And(e => e.Phone.Contains(txtPhone.Text));
            if (Utility.IsValidEmailAddress(txtEmail.Text))
                predicate = predicate.And(e => e.EmailAddress.Contains(txtEmail.Text));
            var results = cust.Where(predicate);
            
            return results;
        }
        //private void CreateEmpQuery()
        //{
        //    TestDataClassDataContext dc = new TestDataClassDataContext();
            
        //    var emp = from c in dc.Contacts
        //              from e in dc.Employees
        //              where c.ContactID == e.ContactID
        //              select new 
        //              {
        //                  FirstName = c.FirstName,LastName = c.LastName, MiddleName =c.MiddleName, Phone = c.Phone,
        //                  EmailAddress = c.EmailAddress
        //              };
            
        //    var predicate = PredicateBuilder.True<>();
        //    if (!string.IsNullOrEmpty(txtLname.Text))
        //        predicate = predicate.And(e => e.LastName.Contains(txtLname.Text));
        //    if (!string.IsNullOrEmpty(txtFname.Text))
        //        predicate = predicate.And(e => e.FirstName.Contains(txtFname.Text));
        //    if (!string.IsNullOrEmpty(txtMname.Text))
        //        predicate = predicate.And(e => e.MiddleName.Contains(txtMname.Text));
        //    if (Utility.IsValidPhone(txtPhone.Text))
        //        predicate = predicate.And(e => e.Phone.Contains(txtPhone.Text));
        //    if (Utility.IsValidEmailAddress(txtEmail.Text))
        //        predicate = predicate.And(e => e.EmailAddress.Contains(txtEmail.Text));
        //    var results = emp.Where(predicate);
      
        //}
        private void GetCustResults()
        {
            _conResults = CreateCustQuery();
            gdvCust.DataSource = _conResults;
            gdvCust.DataBind();
        }
        //private void GetEmpResults()
        //{
        //    _empResults = CreateEmpQuery();
        //    gdvEmp.DataSource = _empResults;
        //    gdvEmp.DataBind();
        //}
        protected void gdvCust_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvCust.PageIndex = e.NewPageIndex;
            gdvCust.DataSource = _conResults;
            gdvCust.DataBind();
        }
        //protected void gdvEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gdvCust.PageIndex = e.NewPageIndex;
        //    gdvEmp.DataSource = _empResults;
        //    gdvEmp.DataBind();
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSelector.SelectedValue == "Customer")
                GetCustResults();
            //else
                //GetEmpResults();
        }
    }
    }
