           var MatData = from Data in dt_TDATA.AsEnumerable()
              join mat in dtDealMat.AsEnumerable() on Data.Field<string>("MATNR") equals mat.Field<string>("vMATNR")
              select new {
                    MATNR = Data.Field<string>("MATNR"),
                    MAKTX = Data.Field<string>("MAKTX"),
                    PHY_STK = Data.Field<string>("PHY_STK"),
                    LABST = Data.Field<string>("LABST")
              };
