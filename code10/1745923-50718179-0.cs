    private void button1_Click(object sender, EventArgs e)
            {
                var folders = ProcessNode("My Folder\\Media\\Mov\\QT", 0);
                MessageBox.Show("finished");
    
            }
            private Folder ProcessNode(string input, int index)
            {
                var newIndex = input.IndexOf("\\", index + 1);
                if (newIndex < 0) return new Folder() { FolderName = input.Substring(index, input.Length - index) };
                var nodeName = input.Substring(index, newIndex - index);
                var thisFolder = new Folder()
                {
                    FolderName = nodeName,
                    Folders = new List<Folder>()
                };
                thisFolder.Folders.Add(ProcessNode(input, newIndex));
                return thisFolder;
            }
