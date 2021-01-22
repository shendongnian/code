            public Error(SerializationInfo info, StreamingContext context)
            {
                if (info != null)
                {
                    try
                    {
                        this.ErrorMessage = info.GetString("ErrorMessage");
                    }
                    catch (Exception e) {
                        **this.ErrorMessage = info.GetString("message");**
                    }
                }
                   
            }
