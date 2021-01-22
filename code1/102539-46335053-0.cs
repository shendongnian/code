    **First Create One class like** 
    
    public class Encryption
        { 
            public static string Encrypt(string clearText)
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;
            }
    
            public static string Decrypt(string cipherText)
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
        }
    
    
    
    **In Controller **
    add reference for this Ecription class
    like....
    using testdemo.Models
    
    public ActionResult Index() {
                return View();
            }
            [HttpPost]
            public ActionResult Index(string text)
            {
                if (Request["txtEncrypt"] != null)
                {
                    string getEncryptionCode = Request["txtEncrypt"];
                    string DecryptCode = Encryption.Decrypt(HttpUtility.UrlDecode(getEncryptionCode));
                    ViewBag.GetDecryptCode = DecryptCode;
                    return View();
                }
                else {
                    string getDecryptCode = Request["txtDecrypt"];
                    string EncryptionCode = HttpUtility.UrlEncode(Encryption.Encrypt(getDecryptCode));
                    ViewBag.GetEncryptionCode = EncryptionCode;
                    return View();
                }
    
            }
    
    **In View**
    <h2>Decryption Code</h2>
    @using (Html.BeginForm())
    {
        <table class="table-bordered table">
            <tr>
                <th>Encryption Code</th>
                <td><input type="text" id="txtEncrypt" name="txtEncrypt" placeholder="Enter Encryption Code" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color:red">@ViewBag.GetDecryptCode</span>
                </td>
            </tr>
            <tr>
                    <td colspan="2">
                        <input type="submit" id="btnEncrypt" name="btnEncrypt"value="Decrypt to Encrypt code" />
                    </td>
                </tr>
        </table>
    }
        <br />
        <br />
        <br />
        <h2>Encryption Code</h2>
    @using (Html.BeginForm())
    {
        <table class="table-bordered table">
            <tr>
                <th>Decryption Code</th>
                <td><input type="text" id="txtDecrypt" name="txtDecrypt" placeholder="Enter Decryption Code" /></td>
            </tr>
    
            <tr>
                <td colspan="2">
                    <span style="color:red">@ViewBag.GetEncryptionCode</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="submit" id="btnDecryt" name="btnDecryt" value="Encrypt to Decrypt code" />
                </td>
            </tr>
        </table>
    }
