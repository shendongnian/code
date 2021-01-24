    public async Task<Guid> Register(IEnumerable<MediaFile> photos)
    {
        var personGroupId = "XYXNXNX";
        var allPersonGroups = await _faceClient.PersonGroup.ListAsync();
        if (allPersonGroups?.Any(x => x.PersonGroupId == personGroupId) == false)
        {
            await _faceClient.PersonGroup.CreateAsync(personGroupId, "HFFGFGFD"); // creating a new person group if not exits.
        }
        var facesIdFromPhotos = new List<Guid>();
        foreach (var photo in photos)
        {
            using (var stream = photo.GetStream())
            {
                var faces = await _faceClient.Face.DetectWithStreamAsync(stream);
                if (faces?.Length == 0)
                {
                    throw new Exception("NoFaceFound");
                }
                if (faces?.Length > 1)
                {
                    throw new Exception("MultipleFacesFound");
                }
                facesIdFromPhotos.Add(((Microsoft.Azure.CognitiveServices.Vision.Face.Models.DetectedFace)faces[0]).FaceId);
            }
        }
        // Check similarity, with 1 face from the previous detected faces
        var similarityPerson = await _faceClient.Face.IdentifyAsync(facesIdFromPhotos.Take(1).ToList(), personGroupId);
        Guid targetPersonId;
        if (similarityPerson[0].Candidates?.Count > 0)
        {
            targetPersonId = similarityPerson[0].Candidates[0].PersonId;
        }
        else
        {
            var createdPerson = await _faceClient.PersonGroupPerson.CreateAsync(personGroupId, Guid.NewGuid().ToString());
            targetPersonId = createdPerson.PersonId;
        }
        
        // Add faces to Person (already existing or not)
        foreach (var photo in photos)
        {
            await _faceClient.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, targetPersonId, photo.GetStream());
        }
        await _faceClient.PersonGroup.TrainAsync(personGroupId);
        return targetPersonId;
    }
