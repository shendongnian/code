    [System.Serializable]
    public class SavedButton {
        public string BtnName;
        public System.Drawing.Point BtnLocation;
        public System.Drawing.Color BtnColor;
        public System.Drawing.Size BtnSize;
        public static void Save(SavedButton button, string filePath) {
            using (StreamWriter file = File.CreateText(filePath)) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, button);
            }
        }
        public static SavedButton Load(string filePath) {
            SavedButton button = null;
            using (StreamReader file = File.OpenText(filePath)) {
                JsonSerializer serializer = new JsonSerializer();
                button = (SavedButton)serializer.Deserialize(file, typeof(SavedButton));
            }
            return button;
        }
    }
