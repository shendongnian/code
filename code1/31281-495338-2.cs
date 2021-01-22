    using System;
    public partial class Masters_MyMasterPage : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MyString))
            {
                // Do something.
            }
        }
    }
