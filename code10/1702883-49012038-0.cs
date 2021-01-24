            if (Okuma.Scout.SpecCode.NCB.SpecFileIsValid)
            {
                bool THiNK_ALARM = Okuma.Scout.SpecCode.NCB.Bit(  
                                       Okuma.Scout.Enums.NCBSpecGroup.NCB1MG, 4, 3);
                if (THiNK_ALARM)
                {
                    // ...
                }
            }
        }
