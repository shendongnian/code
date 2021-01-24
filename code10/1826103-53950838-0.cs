    public async void AddPersonToGroup(string personGroupId, string name, string pathImage){
        String personGroupId = "actors";
        //Create the Person Group
        await faceServiceClient.CreatePersonGroupAsync(personGroupId, "Actors");
        CreatePersonResult actor1 = await faceServiceClient.CreatePersonAsync(personGroupId, "Tom Cruise");
        
        //Get the directory containing the images.
        const string actorImageDir = @"C:...path";
        //For each .jpg file in the directory, add it to the existing Person in the Person Group.
        foreach(String imagePath in Diretory.GetFiles(actorImageDir, "*.jpg){
            using (Stream s = File.OpenRead(imgPath)) {
                try{
                    //Add the image to the Person in the Person Group.
                    await faceServiceClient.AddPersonFaceAsync(personGroupId, actor1.PersonId, s);
                }catch (Exception e){
                    //Display the message and the source of the exception.
                    Console.WriteLine(e.Message + " " + e.Source);
                }
            }
        }
