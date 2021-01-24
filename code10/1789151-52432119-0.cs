            string url = "https://mywebsite.com/check.php";
            string remoteData = null;
            using (Stream mystream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(mystream))
                remoteData = reader.ReadToEnd();
            Console.WriteLine(remoteData); //The text will be "Access"
            //Pseudecode start
            if (remoteData == "Access")
            {
                useraccess = true;
                Console.WriteLine("Done!");
            }
