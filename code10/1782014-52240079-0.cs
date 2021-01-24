            for (var i = 0; i < src1.Rows.Count; i++)
            {
                var r1 = src1.Rows[i];
                for (var j = 1; j < src2.Rows.Count; j++)
                {
                    var r2 = src2.Rows[j];
                    if (r1[0].Equals(r2[0]) && r1[1].Equals(r2[1]))
                    {
                        r1[2] = r2[2];
                    }
                }
            }
