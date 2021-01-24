    public async void AddPersonToGroup(string personGroupId, string name, string pathImage){
        //Create a Person Group called actors.
        await faceServiceClient.CreatePersonGroupAsync("actors, "Famous Actors");
        //Create a person and assign them to a Person Group called "actors"
        CreatePersonResult friend1 = await faceServiceClient.CreatePersonAsync("actors", "Tom Cruise");
        
        //Get the directory with all the images of the person.
        const string friend1ImageDir = @"C:\Users\ishaa\Documents\Face_Recognition_Pictures\Tom_Cruise\";
        foreach (string imagePath in Directory.GetFiles(friend1ImageDir, "*.jpg")){
            using (Stream s = File.OpenRead(imagePath)){
               try{
                   //Add the faces for the person.
                   await faceServiceClient.AddPersonFaceAsync("actors", friend1.PersonId, s);
               } catch (Exception e){
                   Console.WriteLine(e.Message);
               }
            }
        }
    }
