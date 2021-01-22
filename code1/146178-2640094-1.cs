    // Define a class called HomeWork, make it accessible to other
    // classes in other namespaces
    public class HomeWork {
      // Define a method called GetPictures, no incoming arguments,
      // returns a string[]
      public string[] GetPictures() {
        // Create a new instance of a string array
        string[] pictures = new string[4];
        // Fill the string array with a couple of strings
        pictures[0] = "~/pics/grl.jpg";
        pictures[1] = "~/pics/pop.jpg";
        pictures[2] = "~/pics/str.jpg";
        pictures[3] = "~/pics/unk.jpg";
        // Return the string array
        return pictures;
      }
    }
