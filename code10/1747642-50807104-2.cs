    private T Deserialize<T>(string I_JSON)
        {
            var L_SerBinder = new SerBinder();
            var L_Settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Objects,
                SerializationBinder = L_SerBinder,
            };
            return JsonConvert.DeserializeObject<T>(I_JSON, L_Settings);
        }
