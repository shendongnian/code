    using System.Text.RegularExpressions;
    private bool validateURL()
            {
                
                Regex urlCheck = new Regex("^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$");
                if (urlCheck.IsMatch(txtUrlAddress.Text))
                    return true;
                else
                {
                    MessageBox.Show("The url address you have entered is incorrect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    return false;
    
                }
                 
                
    
    
            }
