    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<string> Experience { get; set; }
        public List<string> Skills { get; set; }
    }
            object fileName = "C:\\Users\\akenna\\template.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            List<Person> personList = new List<Person>(); //Populate your list here
            foreach (Person p in personList)
            {
                // create instance of Word
                var applicationWord = new Microsoft.Office.Interop.Word.Application();
                var wordDoc = applicationWord.Documents.Open(fileName);
                //Supress word becoming visible
                wordDoc.Application.Visible = false;
                wordDoc.Application.WindowState = WdWindowState.wdWindowStateMinimize;
                wordDoc.Activate();
                //Loop through template bookmarks
                foreach (Bookmark bm in wordDoc.Bookmarks)
                {
                    switch (bm.Name)
                    {
                        case "Name":
                            bm.Range.Text = p.Name;
                            break;
                        case "Address":
                            bm.Range.Text = p.Address;
                            break;
                        case "Email":
                            bm.Range.Text = p.Email;
                            break;
                        case "Phone":
                            bm.Range.Text = p.PhoneNumber;
                            break;
                        case "Experiences":
                            var experienceText = "";
                            foreach (var exp in p.Experience)
                            {
                                experienceText = experienceText + exp + Environment.NewLine;
                            }
                            bm.Range.Text = experienceText;
                            break;
                        case "Skills":
                            var skillsText = "";
                            foreach (var skill in p.Skills)
                            {
                                skillsText = skillsText + skill + Environment.NewLine;
                            }
                            bm.Range.Text = skillsText;
                            break;
                    }
                }
                var pathToSave = "C:\\Your Path To Save\\";
                var newFileName = p.Name + "_Resume.docx";
                
                wordDoc.SaveAs(pathToSave + newFileName);
                wordDoc.Close(WdSaveOptions.wdDoNotSaveChanges); //Supresses any messages from word.
                //You must do this to release the COM objects from memory!
                applicationWord.Quit();
                Marshal.ReleaseComObject(applicationWord);
            }
