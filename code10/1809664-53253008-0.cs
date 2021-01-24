    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Unit_8_Cookie_Scouts
    {
        struct CookieStruct
        {
            public string cookieName;
            public decimal cookiePrice;
            public int inventoryNum;
            public decimal valueOfInventory;
        }
    
        public partial class CookeScouts : Form
        {
            //create a List as a field
            private List<CookieStruct> cookieList = new List<CookieStruct>();
    
    
            public CookeScouts()
            {
                InitializeComponent();
    
                cookieList.Add(new CookieStruct() { cookieName = "Peppermint Flatties", cookiePrice = 4.99m, inventoryNum = 8, valueOfInventory = 39.92m });
                cookieList.Add(new CookieStruct() { cookieName = "Chocolate Chippers", cookiePrice = 4.76m, inventoryNum = 17, valueOfInventory = 80.92m });
                cookieList.Add(new CookieStruct() { cookieName = "Pecan Paradise", cookiePrice = 6.82m, inventoryNum = 9, valueOfInventory = 61.38m });
                cookieList.Add(new CookieStruct() { cookieName = "Sugary Shortcake", cookiePrice = 5.99m, inventoryNum = 12, valueOfInventory = 71.88m });
    
                LoadListBox();
            }
    
            private void btnUpdate_Click(object sender, EventArgs e)
            {
                int Index = lstCookies.SelectedIndex;
                //update values with index 0
                tempInfo.cookieName = cookieList[Index].cookieName;
                //create a temp structure object to add values too
                
            }
    
    
            private void LoadListBox()
            {
                string output;
    
                //loop through and add to combo box
                foreach (CookieStruct tempInfo in cookieList)
                {
                    //make output line for combo box
                    output = tempInfo.cookieName;
    
                    //send the output to combo box cboCustomers
                    lstCookies.Items.Add(output);
                }
            }
        }
    }
