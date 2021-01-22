    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections.Specialized;
    
    namespace WindowsApplication10
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                decimal discrimation = 0.75M;
                string formHeading = "The brown dog jumped over the red lazy river, and then took a little nap! Fun!";
                string userSearch = "The brown dog jumped over the red lazy river, and then took a little ";
                //string userSearch = "brown dog nap fun";
                decimal res = CompareText(formHeading, userSearch);
    
                if (res >= discrimation)
                {
                    MessageBox.Show("MATCH!" + res.ToString());
                }
                else 
                {
                    MessageBox.Show("does not match! " + res.ToString());
                }
            }
    
    
            /// <summary>
            /// Returns a percentage of 1 on how many words were matched
            /// </summary>
            /// <returns></returns>
            private decimal CompareText(string formHeading, string userSearch)
            {
                StringCollection formHeadingWords = new StringCollection();
                StringCollection userSearchWords = new StringCollection();
                formHeadingWords.AddRange(System.Text.RegularExpressions.Regex.Split(formHeading, @"\W"));
                userSearchWords.AddRange(System.Text.RegularExpressions.Regex.Split(userSearch, @"\W"));
    
                int wordsFound = 0;
                for (int i1 = 0; i1 < userSearchWords.Count; i1++)
                {
                    if (formHeadingWords.Contains(userSearchWords[i1]))
                        wordsFound += 1;
                }
                return (Convert.ToDecimal(wordsFound) / Convert.ToDecimal(formHeadingWords.Count));
            }
    	}
    }
