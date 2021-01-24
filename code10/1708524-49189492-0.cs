            Parallel.ForEach ( ids,(id)=>
            {
                string typeId, type, value;
                typeId= type=value=string.Empty;
                if (id.Contains(";"))
                {
                    var IdInfo = id.Split(';');
                    if (IdInfo[0] != null)
                    {
                        typeId = Info[0];
                    }
                    if (IdInfo.Length >= 2)
                    { type = IdInfo[1]; }
                    if (IdInfo.Length >= 3)
                    { value = IdInfo[2]; }
                    if (IdInfo.Length >= 4)
                    { isValid = IdInfo[3]=="T" ? true:false; } // T=true
                }
                else
                {
                    return;
                }
                DBInsertMethod("someuniqueId", typeId, type, value, isValid);
            });
