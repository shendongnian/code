            //var person is DTO
            var person= base.Get(id);
            var list = new List<FileDTO>();
            person.file.ForEach(delegate (FileDTO obj)
            {
                if (obj.type_file== (int)TypeFile.Attachment)
                {
                    obj.archive = null;
                    list.Add(obj);
                }
            });
            person.file = list;
            return person;
