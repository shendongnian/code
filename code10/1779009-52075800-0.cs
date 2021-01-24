    using Google.Apis.Json;
    using Google.Apis.Util.Store;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    
    namespace GoogleAuthDataStores
    {
        public class GoogleUserCredential
        {
            [Key]
            public int ID { get; set; }
    
            [Required, Index(IsUnique = true), StringLength(500)]
            public string Key { get; set; }
    
            [Required]
            public string Credentials { get; set; }
        }
    
        internal class EntityFrameworkDataStore : DbContext, IDataStore
        {
            public DbSet<GoogleUserCredential> GoogleUserCredentials { get; set; }
    
            /// <summary>The string used to open the connection.</summary>
            public virtual string ConnectionString { get; set; }
    
            /// <summary>
            /// Creates a new table in the data base if the Users table does not exist within the database used in the connectionstring.
            /// </summary>
            /// <param name="connectionString">The string used to open the connection.</param>
            public EntityFrameworkDataStore(string connectionString) : base(connectionString)
            {
                ConnectionString = connectionString;
            }
    
            /// <summary>
            /// Stores the given value for the given key. It creates a new row in the database with the user id of
            /// (primary key <see cref="GenerateStoredKey"/>) in <see cref="GoogleUserCredentials"/>.
            /// </summary>
            /// <typeparam name="T">The type to store in the data store.</typeparam>
            /// <param name="key">The key.</param>
            /// <param name="value">The value to store in the data store.</param>
            Task IDataStore.StoreAsync<T>(string key, T value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Key MUST have a value");
                }
    
                var serialized = NewtonsoftJsonSerializer.Instance.Serialize(value);
                save(GenerateStoredKey(key), serialized);
                return Task.Delay(0);
            }
    
            /// <summary>
            /// Deletes the given key. It deletes the <see cref="GenerateStoredKey"/> row in
            /// <see cref="GoogleUserCredentials"/>.
            /// </summary>
            /// <param name="key">The key to delete from the data store.</param>
            Task IDataStore.DeleteAsync<T>(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Key MUST have a value");
                }
    
                try
                {
                    var hold = GoogleUserCredentials.Where(a => a.Key == key).FirstOrDefault();
                    GoogleUserCredentials.Remove(hold);
                    SaveChangesAsync();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception("Failed to delete credentials", ex);
                }
    
                return Task.Delay(0);
            }
    
            /// <summary>
            /// Returns the stored value for the given key or <c>null</c> if the matching row (<see cref="GenerateStoredKey"/>
            /// in <see cref="GoogleUserCredentials"/> doesn't exist.
            /// </summary>
            /// <typeparam name="T">The type to retrieve.</typeparam>
            /// <param name="key">The key to retrieve from the data store.</param>
            /// <returns>The stored object.</returns>
            Task<T> IDataStore.GetAsync<T>(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Key MUST have a value");
                }
    
                TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
                var user = GetUserByKey(GenerateStoredKey(key));
                if (user != null)
                {
                    try
                    {
                        tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(user.Credentials));
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                }
                else
                {
                    tcs.SetResult(default(T));
                }
                return tcs.Task;
            }
    
            /// <summary>
            /// Clears all values in the data store. This method deletes all files in <see cref="GoogleUserCredentials"/>.
            /// </summary>
            Task IDataStore.ClearAsync()
            {
                try
                {
                    foreach (var item in GoogleUserCredentials)
                    {
                        GoogleUserCredentials.Remove(item);
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception("Failed to clear credentials", ex);
                }
    
                return Task.Delay(0);
            }
    
            /// <summary>
            /// Checks if the user exists <see cref="GenerateStoredKey"/>.
            /// </summary>
            private GoogleUserCredential GetUserByKey(string key)
            {
                try
                {
                    var user = GoogleUserCredentials.Where(a => a.Key == key).FirstOrDefault();
    
                    if (user != null)
                        return user;
    
                    return null;
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return null;
                }
            }
    
            /// <summary>
            /// Save the credentials.  If the user <see cref="GenerateStoredKey"/> does not exists we insert it other wise we will do an update.
            /// </summary>
            /// <param name="key"></param>
            /// <param name="serialized"></param>
            private void save(string key, string serialized)
            {
                try
                {
                    var user = GoogleUserCredentials.Where(a => a.Key == key).FirstOrDefault();
                    if (user == null)
                    {
                        var hold = new GoogleUserCredential { Key = key, Credentials = serialized };
                        GoogleUserCredentials.Add(hold);
                    }
                    else
                    {
                        var aUser = this.GoogleUserCredentials.Where(a => a.Key == key).FirstOrDefault();
                        aUser.Credentials = serialized;
                    }
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            /// <summary>Creates a unique stored key based on the key and the current project name.</summary>
            /// <param name="key">The object key.</param>
            public static string GenerateStoredKey(string key)
            {
                return string.Format("{0}-{1}", Assembly.GetCallingAssembly().GetName().Name, key);
            }
        }
    }
