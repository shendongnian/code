            for (int i=nihItems.count; i >= 0; i--)
            {
                moveMail collectionItem = nihItems[i] as MailItem
                if (moveMail != null)
                {
                    Console.WriteLine("Moving {0}", moveMail.Subject.ToString());
                    string titleSubject = (string)moveMail.Subject;
                    moveMail.Move(nihArchive);
                }
             }
