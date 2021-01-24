            using (var writer = new StreamWriter("file.csv"))
            {
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.Delimiter = ";";
                    csvWriter.Configuration.Encoding = Encoding.UTF8;
                    csvWriter.WriteField("rtb1_list ");
                    csvWriter.WriteField("rtb2_list ");
                    csvWriter.WriteField("rtb3_list ");
                    csvWriter.WriteField("rtb4_list ");
                    csvWriter.NextRecord();
                    csvWriter.WriteField(Savestate.rtb1_list.GetRtbListAsString());
                    csvWriter.WriteField(Savestate.rtb2_list.GetRtbListAsString());
                    csvWriter.WriteField(Savestate.rtb3_list.GetRtbListAsString());
                    csvWriter.WriteField(Savestate.rtb4_list.GetRtbListAsString());
                    csvWriter.NextRecord();
                }
            }
