        ExecuteProcedures EX = new ExecuteProcedures(3, MasterCommonStrings.ConnectionString);
        EX.Parameters.Add("@TableName", SqlDbType.VarChar, 8000, strTableName);
        EX.Parameters.Add("@ColumnName", SqlDbType.VarChar, 8000, strColumnName);
        EX.Parameters.Add("@ColumnValue", SqlDbType.VarChar, 8000, Value);
        int i = Convert.ToInt32(EX.InvokeProcedure("Proc_Erp_Trn_Deleted_Transction_Total_Dre", SqlTra, ValueDataType.Number, Con));
        return i;
    }
        public static bool Ischecked(CheckBox Chkbox)
        {
            bool Status = false;
            if (Chkbox.Checked == true)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            return Status;
        }
            public static string Decrypt(string TextToBeDecrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "CSC";
            byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted.Replace("*plus*", "+").Replace("*amp*", "&"));
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            //Making of the key for decryption
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric Rijndael decryptor object.
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            //Defines the cryptographics stream for decryption.THe stream contains decrpted data
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] PlainText = new byte[EncryptedData.Length];
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
            memoryStream.Close();
            cryptoStream.Close();
            //Converting to string
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            DecryptedData = DecryptedData;
            return DecryptedData;
        }
        public static void Enable_Btn_For_Add(Button btnAdd,Button btnCancel,Button btnDelete,Button btnEdit,Button btnUpdate,Button btnexit,Button btnfind,Button btnprint)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnexit.Enabled  = true;
            btnfind.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnprint.Enabled = false;
        }
    public static void Enable_Btn_For_Find(Button btnAdd, Button btnCancel, Button btnDelete, Button btnEdit, Button btnUpdate, Button btnexit, Button btnfind, Button btnprint)
    {
        btnAdd.Enabled = false ;
        btnEdit.Enabled = true;
        btnexit.Enabled = true;
        btnfind.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = true;
        btnCancel.Enabled = true;
        btnprint.Enabled = true ;
    }
    public static void Enable_Btn_Audit(Button btnAdd, Button btnCancel, Button btnDelete, Button btnEdit, Button btnUpdate, Button btnexit, Button btnfind, Button btnprint)
    {
        btnAdd.Visible = false;
        btnEdit.Visible = false;
        btnexit.Visible = false;
        btnfind.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnCancel.Visible = false;
        btnprint.Visible = false;
    }
    public static void Enable_Btn_For_Update(Button btnAdd, Button btnCancel, Button btnDelete, Button btnEdit, Button btnUpdate, Button btnexit, Button btnfind)
    {
        btnEdit.Enabled = false;
        btnAdd.Enabled = true;
        btnfind.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
        btnCancel.Enabled = false;
        btnexit.Enabled = true;
    }
    public static void Enable_Btn_For_Find(Button btnAdd, Button btnCancel, Button btnDelete, Button btnEdit, Button btnUpdate, Button btnexit, Button btnfind)
    {
        btnAdd.Enabled = true;
        btnEdit.Enabled = true;
        btnexit.Enabled = true;
        btnfind.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = true;
        btnCancel.Enabled = true;
         
    }
    public static void Enable_Btn_For_Edit(Button btnAdd, Button btnCancel, Button btnDelete, Button btnEdit, Button btnUpdate, Button btnexit, Button btnfind)
    {
        btnEdit.Enabled = false;
        btnAdd.Enabled = false;
        btnfind.Enabled = true;
        btnUpdate.Enabled = true;
        btnDelete.Enabled = true;
        btnCancel.Enabled = true;
        btnexit.Enabled = true;
    }
        public static string UploadFile(FileUpload fp,string DisplayPrefixPath,string PrefixPath)
        {
            string image1="";
            
            if (fp.HasFile)
            {
                image1 = GetUniqueKeys() + DateTime.Now.ToString("ddMMMyyyyHHmmss") + Path.GetExtension(fp.FileName).ToString();  //Session.ses Path.GetFileName(fp.FileName).ToString();
                fp.SaveAs(HttpContext.Current.Server.MapPath(PrefixPath + image1));
                image1 = DisplayPrefixPath + image1;
            }
            return image1; 
        }
        public static string UploadFile(FileUpload fp, string PrefixPath)
        {
            string image1 = "";
            if (fp.HasFile)
            {
                image1 = GetUniqueKeys() + DateTime.Now.ToString("ddMMMyyyyHHmmss") + Path.GetExtension(fp.FileName).ToString();  //Session.ses Path.GetFileName(fp.FileName).ToString();
                fp.SaveAs(HttpContext.Current.Server.MapPath(PrefixPath + image1));
                image1 = PrefixPath + image1;
            }
            return image1;
        }   
        public static bool DeleteFile(string FilePath)
        {
            FileInfo fp = null;
            try
            {
                 fp = new FileInfo(HttpContext.Current.Server.MapPath(FilePath));
                if (fp.Exists == true)
                {
                    fp.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                fp = null;
            }
        }
        public static string[] SplitString(string StringToSplit,SplitChar Char)
        {
            string[] arr;
            char Split;
            switch (Char)
            {
                case SplitChar.Comma:
                    Split = (char)44;
                    break;
                case SplitChar.SemiColon:
                    Split = (char)59;
                    break;
                case SplitChar.BackSlash:
                    Split = (char)92;
                    break;
                case SplitChar.FrontSlash:
                    Split = (char)47;
                    break;
                case SplitChar.Dot:
                    Split = (char)46;
                    break;
                case SplitChar.Colon:
                    Split = (char)58;
                    break;
                default :
                    Split = (char)44;
                    break;
            }
            arr = StringToSplit.Split(Split);
            return arr;
        }
        public static string  GetUniqueKeys()
        {
            int maxSize = 8;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();
        }
        public static string EncodeHTML(string HTML)
        {
            return HttpUtility.HtmlEncode(HTML);
        }
        
        public static string DecodeHTML(string HTML)
        {
            return HttpUtility.HtmlDecode(HTML);
        }     
        public static object GetDbNull(string strValue)
        {
            if (strValue == "")
            {
                return DBNull.Value;
            }
            else
            {
                return strValue;
            }
        }
        public static string Format_Date(string Date)
        {
            string strDate = "";
            if (Date != "") 
            {
                try
                {
                    strDate = Convert.ToDateTime(Date).ToString("dd/MMM/yyyy");
                }
                catch
                {
                }
            }
            return strDate;
        }
    public static string Get_Date_Change(string Date)
    {
        string strDate = "";
        if (Date != "")
        {
            try
            {
                strDate = Convert.ToDateTime(Date).ToString("dd/MM/yyyy");
            }
            catch
            {
            }
        }
        return strDate;
    }
    public static string Convert_MM_DD_YYYY(string Box) //===BY Yogesh Bodke
    {
        string str = Box;
        string mm, dd, yy;
        int len = Box.Length;
        if (len == 10)
        {
            string[] str1 = str.Split(new Char[] { '/' });
            dd = str1[0];
            mm = str1[1];
            yy = str1[2];
            Box = mm + "/" + dd + "/" + yy;
            // DateTime bb = Convert.ToDateTime(Box);
        }
        return Box;
    }
    public static string Get_Date_Change_New(string Date)
    {
        string strDate = Date.Substring(3, 2) + "/" + Date.Substring(0, 2) +"/"+ Date.Substring(6, 4);
        if (Date != "")
        {
            try
            {
                strDate = Convert.ToDateTime(strDate).ToString("MM/dd/yyyy");
            }
            catch
            {
            }
        }
        return strDate;
