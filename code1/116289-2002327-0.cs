    using System;
    using System.DirectoryServices;
    using System.Collections;
    using System.IO;
    
    public class ADPhoto {
    public void Set() {
      try {
        var de = new DirectoryEntry("LDAP://cn=username,cn=users,DC=domain, DC=com");
        de.Username = "username";
        de.Password = "password";
        var forceAuth = de.NativeObject;
        var fs = new FileStream("path\\photo.jpg", FileMode.Open);
        var br = new BinaryReader(fs);    
        br.BaseStream.Seek(0, SeekOrigin.Begin);
        byte[] ba = new byte[br.BaseStream.Length];
        ba = br.ReadBytes((int)br.BaseStream.Length);
        de.Properties["jpegPhoto"].Insert(0, ba);
        de.CommitChanges();
      }
      catch(Exception ex) {
        Console.WriteLine(ex.Message);
      }
    }
    public Stream Get() {
      var fs = new MemoryStream();
      try {
        var de = new DirectoryEntry("LDAP://cn=username,cn=users,DC=domain, DC=com");
        de.Username = "username";
        de.Password = "password";
        var forceAuth = de.NativeObject;
        var wr = new BinaryWriter(fs);
        byte[] bb = (byte[])de.Properties["jpegPhoto"][0];
        wr.Write(bb);
        wr.Close();
      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
      }
      return fs;
    }
    }
