    InputStream in = null;
    try {
        in = new FileInputStream("file.txt");
        // Do something that causes an IOException to be thrown
    } finally {
        if (in != null) {
             try {
                 in.close();
             } catch (IOException e) {
                 // Nothing we can do.
             }
        }
    }
