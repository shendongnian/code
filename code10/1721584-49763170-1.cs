        public static Person GetPerson2()
        {
            var p = new Person();
            var pl = GetPhoneList();
            pl.Foreach(ph =>
            {
                switch (ph.Type)
                {
                    case PhoneType.Home: p.HomePhone = ph; break;
                    case PhoneType.Work: p.WorkPhone = ph; break;
                    case PhoneType.Cell: p.CellPhone = ph; break;
                }                
            });
            return p;
        }
