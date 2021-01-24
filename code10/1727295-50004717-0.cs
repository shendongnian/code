     var set = from E in ENERGY_PROFILE
                         join A in ALL_COSEM_OBJECTS
                         on E.Cosem_Object.Substring(0, (E.Cosem_Object + "*").IndexOf('*')) equals A.Short_Cosem_Object
                         into joinedTb
                         from c in joinedTb.DefaultIfEmpty()
                         select new
                         {   
                             E.Cosem_Object,
                             Explanation = c.Explanation ?? "Not Available",
                             c.Unit,
                             E.Reading,
                             Unit2 = E.Unit,
                             E.Meter_Date,
                             E.Meter_Time
                         };
