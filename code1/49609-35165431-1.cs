            while (reader2.Read()) {
                string[] columns = reader2.CurrentRecord;
                CdsRawPayfileEntry toAdd = new CdsRawPayfileEntry() {
                    ColumnZero = columns[0],
                    ColumnOne = columns[1],
                    ColumnTwo = columns[2],
                    ColumnThree = columns[3],
                    ColumnFour = columns[4],
                    ColumnFive = columns[5],
                    ColumnSix = columns[6],
                    ColumnSeven = columns[7],
                    ColumnEight = columns[8],
                    ColumnNine = columns[9],
                    ColumnTen = columns[10],
                    ColumnEleven = columns[11],
                    ColumnTwelve = columns[12],
                    ColumnThirteen = columns[13],
                    ColumnFourteen = columns[14],
                    ColumnFifteen = columns[15],
                    ColumnSixteen = columns[16],
                    ColumnSeventeen = columns[17]
                };
            }
