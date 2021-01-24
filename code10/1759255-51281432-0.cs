    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Security;
	using System.Security.Cryptography;
	using System.Runtime.InteropServices;
	using System.IO;
	namespace BerndoJLib.Cryptography
	{
		/// <summary>
		/// 
		/// A helper class that controls security encrypting and decrypting of the database.
		/// Contains the methods to encrypt and decrypt byte arrays.
		/// 
		/// </summary>
		/// <remarks>
		/// Author: berndoJ / Copyright 2018 Johannes Berndorfer
		/// Created: 13.03.2018 11:20:56
		/// </remarks>
		public class Cryptographer
		{
			#region Public Objects
			/// <summary>
			/// Sets the options of this cryptographer / the algorithm options
			/// </summary>
			public EncryptionOptions AlgorithmOptions { get; set; }
			#endregion
			#region Constructor
			/// <summary>
			/// Constructor of this class.
			/// </summary>
			/// <param name="AlgorithmOptions">The options of this cryptographer instance</param>
			public Cryptographer(EncryptionOptions AlgorithmOptions)
			{
				this.AlgorithmOptions = AlgorithmOptions;
			}
			#endregion
			#region Methods
			/// <summary>
			/// A function to generate a new sequence to use as a salt for one encryption.
			/// The byte-length of this sequence is set by the <see cref="AlgorithmOptions"/> property.
			/// The random byte generator <see cref="RNGCryptoServiceProvider"/> is a good option to use in this case.
			/// </summary>
			/// <returns>The sequence of bytes in an array</returns>
			public byte[] GenerateNewSaltSequence()
			{
				byte[] SaltSequence = new byte[this.AlgorithmOptions.SaltByteLength];
				RNGCryptoServiceProvider RNGCsp = new RNGCryptoServiceProvider();
				RNGCsp.GetNonZeroBytes(SaltSequence);
				return SaltSequence;
			}
			/// <summary>
			/// This function derives a specified byte array (length spec) from a string key entered. The key does not have to be from a certain length.
			/// For maintaining security, the byte[] returned by this function should be set to zero if not used anymore.
			/// The method used to achieve this process is made available by the <see cref="Rfc2898DeriveBytes"/> class.
			/// The count of iterations of this process is set by the <see cref="AlgorithmOptions"/> property.
			/// </summary>
			/// <param name="Key">The key in the form of a SecureString</param>
			/// <param name="KeySize">The size (in bits) of the key generated</param>
			/// <param name="SaltSequence">The salt sequence used to hash the key</param>
			/// <returns>A key in form of a byte array derived from the string counterpart</returns>
			public byte[] DeriveKeyFromString(SecureString Key, int KeySize, byte[] SaltSequence)
			{
				/*DeriveBytes DrvBytes = new Rfc2898DeriveBytes(Key, SaltSequence, this.AlgorithmOptions.KeyGenerationIterations);
				return DrvBytes.GetBytes(KeySize >> 3);*/ // The >> 3 just gets the floored value of bytes.
				IntPtr StrPtr = Marshal.SecureStringToBSTR(Key);
				byte[] PwdByteArray = null;
				try
				{
					int StrLength = Marshal.ReadInt32(StrPtr, -4);
					PwdByteArray = new byte[StrLength];
					GCHandle Handle = GCHandle.Alloc(PwdByteArray, GCHandleType.Pinned);
					try
					{
						for (int i = 0; i < StrLength; i++)
							PwdByteArray[i] = Marshal.ReadByte(StrPtr, i);
						using (Rfc2898DeriveBytes DrvBytes = new Rfc2898DeriveBytes(PwdByteArray, SaltSequence, this.AlgorithmOptions.KeyGenerationIterations))
							return DrvBytes.GetBytes(KeySize >> 3);
					}
					finally
					{
						Array.Clear(PwdByteArray, 0, PwdByteArray.Length);
						Handle.Free();
					}
				}
				finally
				{
					Marshal.ZeroFreeBSTR(StrPtr);
				}
			}
			/// <summary>
			/// Encrypts the given data (in form of a byte[]) with the Key given. All the options and so on are defined by the <see cref="AlgorithmOptions"/> property.
			/// </summary>
			/// <param name="DataIn">The data given to the function in form of a byte array</param>
			/// <param name="Key">The key to encrypt the data</param>
			/// <returns>An EncryptedData object which contains IV, Salt and EncryptedData</returns>
			public EncryptedData Encrypt(byte[] DataIn, SecureString Key)
			{
				// EncryptedData context init
				EncryptedData EncryptedDataContext = new EncryptedData();
				EncryptedDataContext.Salt = this.GenerateNewSaltSequence();
				// CSP init
				using(AesCryptoServiceProvider AESCsp = new AesCryptoServiceProvider())
				{
					// Generate the IV and store it in the EncryptedData context.
					AESCsp.GenerateIV();
					EncryptedDataContext.IV = AESCsp.IV;
					// Derive the byte[] key from the string key
					AESCsp.Key = this.DeriveKeyFromString(Key, AESCsp.KeySize, EncryptedDataContext.Salt);
					// Init the CSP options
					AESCsp.Mode = this.AlgorithmOptions.CipherModeUsed;
					AESCsp.Padding = this.AlgorithmOptions.PaddingModeUsed;
					// Encryption code
					using (MemoryStream MemStrm = new MemoryStream(DataIn.Length))
					{
						using (ICryptoTransform EncryptionTransformer = AESCsp.CreateEncryptor())
						{
							using (CryptoStream CryptoStrm = new CryptoStream(MemStrm, EncryptionTransformer, CryptoStreamMode.Write))
							{
								CryptoStrm.Write(DataIn, 0, DataIn.Length);
								CryptoStrm.FlushFinalBlock();
								EncryptedDataContext.EncryptedDataContent = MemStrm.ToArray();
							}
						}
					}
					// Disposing the key object in the AESCsp to reduce chance of acidentially leaving it in memory after the using closed AESCsp.
					Array.Clear(AESCsp.Key, 0, AESCsp.Key.Length);
					// Returning the EncryptedData
					return EncryptedDataContext;
				}
			}
			/// <summary>
			/// Decrypts the given encrypted data with the use of the given key.
			/// <para>
			/// Returns a tuple which contains the following information: If the decryption was successful (If the key was the right one) and the decrypted data if the decrpyton was in fact successful.
			/// </para>
			/// </summary>
			/// <param name="EncryptedDataIn">The data given to the decryption method</param>
			/// <param name="Key">The key to decrypt the data</param>
			/// <returns>A tuple with: The successfulness of the decryption (is key correct); The decrypted data;</returns>
			public Tuple<bool, byte[]> Decrypt(EncryptedData EncryptedDataIn, SecureString Key)
			{
				// Create a return tuple, Item1 is the successfulness, Item2 the decrypted data if the decryption was successful.
				Tuple<bool, byte[]> DecryptionResult = new Tuple<bool, byte[]>(false, null);
				try
				{
					using (AesCryptoServiceProvider AESCsp = new AesCryptoServiceProvider())
					{
						// Init the IV
						AESCsp.IV = EncryptedDataIn.IV;
						// Init the AESCsp key object
						AESCsp.Key = this.DeriveKeyFromString(Key, AESCsp.KeySize, EncryptedDataIn.Salt);
						// Init the CSP options
						AESCsp.Mode = this.AlgorithmOptions.CipherModeUsed;
						AESCsp.Padding = this.AlgorithmOptions.PaddingModeUsed;
						// Decryption code
						using (MemoryStream MemStrm = new MemoryStream(EncryptedDataIn.EncryptedDataContent))
						{
							using (ICryptoTransform DecryptionTransformer = AESCsp.CreateDecryptor())
							{
								using (CryptoStream CryptoStrm = new CryptoStream(MemStrm, DecryptionTransformer, CryptoStreamMode.Read))
								{
									using (MemoryStream SequenceMemStrm = new MemoryStream())
									{
										// Define a buffer to read sequences.
										byte[] SequenceBuffer = new byte[2048];
										// Init a variable that keeps track of how many bytes have been written to the buffer
										int ReadBytes;
										// Loop to read all the bytes in the CryptoStrm
										while((ReadBytes = CryptoStrm.Read(SequenceBuffer, 0, SequenceBuffer.Length)) > 0)
										{
											SequenceMemStrm.Write(SequenceBuffer, 0, ReadBytes);
										}
										// Set the DecryptionResult to: successful; Data in SequenceMemStrm;
										DecryptionResult = new Tuple<bool, byte[]>(true, SequenceMemStrm.ToArray());
									}
								}
							}
						}
						// Disposing the key object in the AESCsp to reduce chance of acidentially leaving it in memory after the using closed AESCsp.
						Array.Clear(AESCsp.Key, 0, AESCsp.Key.Length);
						// Returning the DecryptionResult
						return DecryptionResult;
					}
				}
				catch (Exception)
				{
					// The decryption failed, the key is not the right one.
					DecryptionResult = new Tuple<bool, byte[]>(false, null);
					return DecryptionResult;
				}
			}
			#endregion
		}
		/// <summary>
		/// 
		/// A struct obhject that defines a data set containing information of the salt, iv and the encrypted content.
		/// 
		/// </summary>
		/// <remarks>
		/// Author: berndoJ / Copyright 2018 Johannes Berndorfer
		/// Created: 13.03.2018 11:20:56
		/// </remarks>
		public struct EncryptedData
		{
			/// <summary>
			/// The initialization vector of the encryption
			/// </summary>
			public byte[] IV { get; set; }
			/// <summary>
			/// The salt used to genereate a key from a password string
			/// </summary>
			public byte[] Salt { get; set; }
			/// <summary>
			/// The encrypted data content of this struct
			/// </summary>
			public byte[] EncryptedDataContent { get; set; }
		}
		/// <summary>
		/// 
		/// A class that contains some options used for the encryption/decryption process.
		/// The objects in the class are readonly, set only when instanciating the class.
		/// 
		/// </summary>
		/// <remarks>
		/// Author: berndoJ / Copyright 2018 Johannes Berndorfer
		/// Created: 13.03.2018 11:20:56
		/// </remarks>
		public class EncryptionOptions
		{
			#region Presets
			/// <summary>
			/// The default encryption options for the cryptographer.
			/// </summary>
			public static readonly EncryptionOptions DEFAULT_OPTS = new EncryptionOptions(3000, 128, CipherMode.CBC, PaddingMode.PKCS7);
			#endregion
			#region Public Objects
			/// <summary>
			/// Defines how many iterations should be done when generating a key from a string password
			/// Standart is 3000 / Minimum is 1000
			/// </summary>
			public int KeyGenerationIterations { get; private set; }
			/// <summary>
			/// Defines the byte length of a standart generated salt.
			/// The minimum value is 64. Standart is 128
			/// </summary>
			public int SaltByteLength { get; private set; }
			/// <summary>
			/// Defines the cipher mode used.
			/// Standard is <see cref="CipherMode.CBC"/>
			/// </summary>
			public CipherMode CipherModeUsed { get; private set; }
			/// <summary>
			/// Defines the padding mode used in the process.
			/// Standard is <see cref="PaddingMode.PKCS7"/>
			/// </summary>
			public PaddingMode PaddingModeUsed { get; private set; }
			#endregion
			#region Constructor
			/// <summary>
			/// Constructor of this class.
			/// </summary>
			/// <param name="SaltGenerationIterations">Iterations when generating salt.</param>
			/// <param name="CipherModeUsed">The cipher mode used in the process.</param>
			/// <param name="PaddingModeUsed">The padding mode used in the process.</param>
			public EncryptionOptions(int KeyGenerationIterations, int SaltByteLength, CipherMode CipherModeUsed, PaddingMode PaddingModeUsed)
			{
				if (KeyGenerationIterations < 1000) throw new InvalidOperationException();
				if (SaltByteLength < 64) throw new InvalidOperationException();
				this.KeyGenerationIterations = KeyGenerationIterations;
				this.SaltByteLength = SaltByteLength;
				this.CipherModeUsed = CipherModeUsed;
				this.PaddingModeUsed = PaddingModeUsed;
			}
			#endregion
			#region Methods
			/// <summary>
			/// Gets the serialized version of an instance of this class.
			/// </summary>
			/// <returns>The serialized version of this class.</returns>
			public string GetSerialized()
			{
				// Init of SerializedString
				string SerializedString = "";
				// Key gen iterations
				SerializedString += $"KeyGenIterations:{this.KeyGenerationIterations.ToString()}";
				// Salt byte length
				SerializedString += $";SaltByteLength:{this.SaltByteLength.ToString()}";
				// Cipher mode
				string CipherModeStr = "";
				switch (this.CipherModeUsed)
				{
					case CipherMode.CBC:
						CipherModeStr = "CBC";
						break;
					case CipherMode.CFB:
						CipherModeStr = "CFB";
						break;
					case CipherMode.CTS:
						CipherModeStr = "CTS";
						break;
					case CipherMode.ECB:
						CipherModeStr = "ECB";
						break;
					case CipherMode.OFB:
						CipherModeStr = "OFB";
						break;
					default:
						CipherModeStr = "CBC";
						break;
				}
				SerializedString += $";CipherMode:{CipherModeStr}";
				// Padding mode
				string PaddingModeStr = "";
				switch (this.PaddingModeUsed)
				{
					case PaddingMode.ANSIX923:
						PaddingModeStr = "ANSIX923";
						break;
					case PaddingMode.ISO10126:
						PaddingModeStr = "ISO10126";
						break;
					case PaddingMode.None:
						PaddingModeStr = "None";
						break;
					case PaddingMode.PKCS7:
						PaddingModeStr = "PKCS7";
						break;
					case PaddingMode.Zeros:
						PaddingModeStr = "Zeros";
						break;
					default:
						PaddingModeStr = "PKCS7";
						break;
				}
				SerializedString += $";PaddingMode:{PaddingModeStr}";
				// Return
				return SerializedString;
			}
			#endregion
			#region Static Methods
			/// <summary>
			/// Deserializes a string to this class
			/// </summary>
			/// <param name="SerializedString">The serialized class</param>
			/// <returns>The class</returns>
			public static EncryptionOptions Deserialize(string SerializedString)
			{
				// Init of fields
				int KeyGenIterations = 3000;
				int SaltByteLength = 128;
				CipherMode CipherModeUsed = CipherMode.CBC;
				PaddingMode PaddingModeUsed = PaddingMode.PKCS7;
				// Init of strings
				try
				{
					string[] Components = SerializedString.Split(';');
					if (Components.Length == 4)
					{
						// Key gen iterations
						string Comp1 = Components[0];
						string[] Comp1Vals = Comp1.Split(':');
						KeyGenIterations = int.Parse(Comp1Vals[1]);
						// Salt byte length
						string Comp2 = Components[1];
						string[] Comp2Vals = Comp2.Split(':');
						SaltByteLength = int.Parse(Comp2Vals[1]);
						// Cipher mode
						string Comp3 = Components[2];
						string[] Comp3Vals = Comp3.Split(':');
						switch (Comp3Vals[1])
						{
							case "CBC":
								CipherModeUsed = CipherMode.CBC;
								break;
							case "CFB":
								CipherModeUsed = CipherMode.CFB;
								break;
							case "CTS":
								CipherModeUsed = CipherMode.CTS;
								break;
							case "ECB":
								CipherModeUsed = CipherMode.ECB;
								break;
							case "OFB":
								CipherModeUsed = CipherMode.OFB;
								break;
							default:
								CipherModeUsed = CipherMode.CBC;
								break;
						}
						// Padding mode
						string Comp4 = Components[3];
						string[] Comp4Vals = Comp4.Split(':');
						switch (Comp4Vals[1])
						{
							case "ANSIX923":
								PaddingModeUsed = PaddingMode.ANSIX923;
								break;
							case "ISO10126":
								PaddingModeUsed = PaddingMode.ISO10126;
								break;
							case "None":
								PaddingModeUsed = PaddingMode.None;
								break;
							case "PKCS7":
								PaddingModeUsed = PaddingMode.PKCS7;
								break;
							case "Zeros":
								PaddingModeUsed = PaddingMode.Zeros;
								break;
							default:
								PaddingModeUsed = PaddingMode.PKCS7;
								break;
						}
					}
				}
				catch (Exception) { }
				return new EncryptionOptions(KeyGenIterations, SaltByteLength, CipherModeUsed, PaddingModeUsed);
			}
			#endregion
		}
	}
