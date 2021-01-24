    ...
    namespace BSoft
    {
     public interface ISaveAndLoad
     {
        void SaveFile(string filename, string text);
        bool CheckExistingFile(string filename);
        string ReadFile(string filename);
     }
    }
