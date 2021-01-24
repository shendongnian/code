    using System;
    using System.Data.SqlClient;
    namespace QueryExample {
        public class Example {
            public static void Run() {
                using (var connection = new SqlConnection(string.Empty)) {
                    var query = new Query(connection);
                    const string text = "SELECT TOP 1 fi.financialimpactid, " +
                        "fi.effectivedate " +
                        " FROM FinancialImpact fi " +
                        " INNER JOIN [Case] c ON c.caseid = " +
                        "fi.caseid " +
                        " WHERE fi.isDeleted = 0 AND " +
                        "c.IsDeleted = 0";
                    var results = query.Run(text, GetData);
                    // do something with the results
                }
            }
            private static Data GetData(SqlDataReader reader) => new Data {
                FinancialImpactId = reader.GetInt32(0),
                EffectiveDate = reader.GetDateTime(1)
            };
        }
        internal class Data {
            public int FinancialImpactId { get; set; }
            public DateTime EffectiveDate { get; set; }
        }
    }
