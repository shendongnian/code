    using(var stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
    {
        var serializer = new DataContractJsonSerializer(typeof(COJson));
        var jsonDto = (COJson)ser.ReadObject(stream);
        var dto = new Response(){
            Id = jsonDto.Id,
            Name = jsonDto.Name,
            Obj = new ConnectedObject(){
                COName = jsonDto.ConnectedObjectName,
                COId = jsonDto.ConnectedObjectId
            }        
        };
        
        return dto;
    }
