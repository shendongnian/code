        private void button1_Click(object sender, EventArgs e)
            {
               
                var splitted = "My Folder\\Media\\Mov\\QT".Split('\\').ToList();
                var foldersList = ProcessNode(splitted, 0);
                MessageBox.Show("finished");
    
            }     
    private Folder ProcessNode(List<string> input, int index)
                {
                    if (index >= input.Count) return null;
                    var thisFolder = new Folder()
                    {
                        FolderName = input[index],
                        Folders = new List<Folder>()
                    };
                    thisFolder.Folders.Add(ProcessNode(input, index + 1));
                    return thisFolder;
                }
