    using System.IO;
    namespace FooCorp.MagicApp {
        public class TextDocument {
            public static void Save(string path, string contents) {
                File.WriteAllText(path, contents);
            }
        }
    }
