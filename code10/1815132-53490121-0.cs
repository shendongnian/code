    using System.Data.SqlTypes;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString ZipEntries(SqlBytes data) {
            using (var stream = new MemoryStream(data.Value))
            using (var archive = new ZipArchive(stream))
                return new SqlString(string.Join(",", archive.Entries.Select(e => e.Name)));
        }
    }
