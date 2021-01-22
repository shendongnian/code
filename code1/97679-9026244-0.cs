    using System.Web;
    using System.Web.Security;
    namespace WebApplication17 {
      public partial class ManageProfile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
          if (!IsPostBack) {
            if (User.Identity.IsAuthenticated) {
              loadProfile();
            } else {
              goHome();
            }
          }
        }
        private void changePassword(string pwdOld, string pwdNew) {
          MembershipUser user = Membership.GetUser(User.Identity.Name);
          user.ChangePassword(pwdOld, pwdNew);
          Membership.UpdateUser(user);
        }
        private void goHome() {
          Server.Transfer("Default.aspx");
        }
        private void loadProfile() {
          MembershipUser user = Membership.GetUser(User.Identity.Name);
          txtEmail.Text = user.Email;
          TextBox3.Text = user.GetPassword();
          var profile = HttpContext.Current.Profile;
          txtTitle.Text = profile.GetPropertyValue("Title").ToString();
          txtName.Text = profile.GetPropertyValue("Name").ToString();
          txtAddress.Text = profile.GetPropertyValue("Address").ToString();
          txtCity.Text = profile.GetPropertyValue("City").ToString();
          txtSt.Text = profile.GetPropertyValue("St").ToString();
          txtZip.Text = profile.GetPropertyValue("Zip").ToString();
          txtPhone.Text = profile.GetPropertyValue("Phone").ToString();
          txtFax.Text = profile.GetPropertyValue("Fax").ToString();
          txtCompany.Text = profile.GetPropertyValue("Company").ToString();
        }
        private void setProfile() {
          MembershipUser user = Membership.GetUser(User.Identity.Name);
          user.Email = txtEmail.Text;
          Membership.UpdateUser(user);
          var profile = HttpContext.Current.Profile;
          profile.SetPropertyValue("Title", txtTitle.Text);
          profile.SetPropertyValue("Name", txtName.Text);
          profile.SetPropertyValue("Address", txtAddress.Text);
          profile.SetPropertyValue("City", txtCity.Text);
          profile.SetPropertyValue("St", txtSt.Text);
          profile.SetPropertyValue("Zip", txtZip.Text);
          profile.SetPropertyValue("Phone", txtPhone.Text);
          profile.SetPropertyValue("Fax", txtFax.Text);
          profile.SetPropertyValue("Company", txtCompany.Text);
          profile.Save();
        }
        protected void Button6_Click(object sender, EventArgs e) {
          changePassword(TextBox3.Text, TextBox4.Text);
          goHome();
        }
        protected void Button11_Click(object sender, EventArgs e) {
          setProfile();
          goHome();
        }
      }
    }
