    static int Main() {
         byte[] data = File.ReadAllBytes("anyfile");
         SomeMethod(new ReadOnlyCollection<byte>(data));
         ...
    }
    static void SomeMethod(ReadOnlyCollection<byte> data) {
         byte b = data[0];       // only reading is allowed
         ...
    }
