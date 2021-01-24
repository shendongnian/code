    public class Repo {
        //set up 'database' variable
        public Repo() {
            CreateTablesAsync()
        }
        private async void CreateTablesAsync() {
            await database.CreateTableAsync<Patient>().ConfigureAwait(false);
            await database.CreateTableAsync<User>().ConfigureAwait(false);
            await database.CreateTableAsync<Setting>().ConfigureAwait(false);
            await database.CreateTableAsync<DeviceSessionDB>().ConfigureAwait(false);
            await database.CreateTableAsync<DeviceSessionRecordingsDB>().ConfigureAwait(false);
        }
    }
