    using System;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.IO;
    namespace DesHack
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] key = new byte[24];
                for (int i = 0; i < key.Length; i++)
                    key[i] = 0x11;
                byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] computedMac = null;
                using (MACTripleDES mac = new MACTripleDESHack(key))
                {
                    computedMac = mac.ComputeHash(data);
                }
            }
        }
        class MACTripleDESHack : MACTripleDES
        {
            TripleDES _desHack = new DesHack();
            static FieldInfo _cspField = typeof(MACTripleDES).GetField("des", BindingFlags.Instance | BindingFlags.NonPublic);
            public MACTripleDESHack()
                : base()
            {
                RewireDes();
            }
            public MACTripleDESHack(byte[] rgbKey)
                : base(rgbKey)
            {
                RewireDes();
            }
            private void RewireDes()
            {
                _cspField.SetValue(this, _desHack);
            }
        }
        class DesHack : TripleDES
        {
            TripleDESCryptoServiceProvider _backing = new TripleDESCryptoServiceProvider();
            static MethodInfo _newEncryptor;
            static object _encrypt;
            static object _decrypt;
            public override int BlockSize
            {
                get
                {
                    return _backing.BlockSize;
                }
                set
                {
                    _backing.BlockSize = value;
                }
            }
            public override int FeedbackSize
            {
                get
                {
                    return _backing.FeedbackSize;
                }
                set
                {
                    _backing.FeedbackSize = value;
                }
            }
            // For these two we ALSO need to avoid
            // the base class - it also checks
            // for weak keys.
            private byte[] _iv;
            public override byte[] IV
            {
                get
                {
                    return _iv;
                }
                set
                {
                    _iv = value;
                }
            }
            private byte[] _key;
            public override byte[] Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }
            public override int KeySize
            {
                get
                {
                    return _backing.KeySize;
                }
                set
                {
                    _backing.KeySize = value;
                }
            }
            public override KeySizes[] LegalBlockSizes
            {
                get
                {
                    return _backing.LegalBlockSizes;
                }
            }
            public override KeySizes[] LegalKeySizes
            {
                get
                {
                    return _backing.LegalKeySizes;
                }
            }
            public override CipherMode Mode
            {
                get
                {
                    return _backing.Mode;
                }
                set
                {
                    _backing.Mode = value;
                }
            }
            public override PaddingMode Padding
            {
                get
                {
                    return _backing.Padding;
                }
                set
                {
                    _backing.Padding = value;
                }
            }
            static DesHack()
            {
                _encrypt = typeof(object).Assembly.GetType("System.Security.Cryptography.CryptoAPITransformMode").GetField("Encrypt").GetValue(null);
                _decrypt = typeof(object).Assembly.GetType("System.Security.Cryptography.CryptoAPITransformMode").GetField("Decrypt").GetValue(null);
                _newEncryptor = typeof(TripleDESCryptoServiceProvider).GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
            }
            public DesHack()
            {            
            }
            public override ICryptoTransform CreateDecryptor()
            {
                return CreateDecryptor(_key, _iv);
            }
            public override ICryptoTransform CreateEncryptor()
            {
                return CreateEncryptor(_key, _iv);
            }
            public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
            {
                // return this._NewEncryptor(rgbKey, base.ModeValue, rgbIV, base.FeedbackSizeValue, CryptoAPITransformMode.Decrypt);
                return (ICryptoTransform) _newEncryptor.Invoke(_backing,
                    new object[] { rgbKey, ModeValue, rgbIV, FeedbackSizeValue, _decrypt });
            }
            public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
            {
                // return this._NewEncryptor(rgbKey, base.ModeValue, rgbIV, base.FeedbackSizeValue, CryptoAPITransformMode.Encrypt);
                return (ICryptoTransform) _newEncryptor.Invoke(_backing,
                    new object[] { rgbKey, ModeValue, rgbIV, FeedbackSizeValue, _encrypt });
            }
            public override void GenerateIV()
            {
                _backing.GenerateIV();
            }
            public override void GenerateKey()
            {
                _backing.GenerateKey();
            }
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    ((IDisposable) _backing).Dispose();
                base.Dispose(disposing);
            }
        }
    }
