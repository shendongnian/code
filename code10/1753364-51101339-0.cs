     using (var document = DocX.Create(@"docs\Lists.docx"))
        {
            var numberedList = document.AddList("First List Item.", 0, ListItemType.Numbered);
                    //Add a numbered list starting at 2
            document.AddListItem(numberedList, "Second List Item.");
            document.AddListItem(numberedList, "Third list item.");
            document.AddListItem(numberedList, "First sub list item", 1);
     
            document.AddListItem(numberedList, "Nested item.", 2);
            document.AddListItem(numberedList, "Fourth nested item.");
     
            var bulletedList = document.AddList("First Bulleted Item.", 0, ListItemType.Bulleted);
            document.AddListItem(bulletedList, "Second bullet item");
            document.AddListItem(bulletedList, "Sub bullet item", 1);
            document.AddListItem(bulletedList, "Second sub bullet item", 2);
            document.AddListItem(bulletedList, "Third bullet item");
     
            document.InsertList(numberedList);
            document.InsertList(bulletedList);
            document.Save();
            Console.WriteLine("\tCreated: docs\\Lists.docx");
        }
