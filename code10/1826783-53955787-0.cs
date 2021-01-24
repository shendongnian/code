    public MobilinkN get(ulong ID)
        {
            SubInfoNEntities robject = new SubInfoNEntities();
            using (SubInfoNEntities entities = new SubInfoNEntities())
            {
                string scnic = ID.ToString();
                if (scnic.Length == 13)
                {
                    return entities.MobilinkNs.FirstOrDefault(e => e.CNIC == scnic);
                }
                else if(scnic.Length == 12)
                { 
                   return entities.MobilinkNs.FirstOrDefault(e => e.MSISDN ==scnic);
                }
                else
                {
                   return null;
                }
               // return entities.MobilinkNs.FirstOrDefault(e => e.MSISDN == scnic);  --> Remove this line
            }
        }
