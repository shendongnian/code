    #if __MonoCS__
        using Mono.Data.Sqlite;
	    using SQLiteCommand =     Mono.Data.Sqlite.SqliteCommand;
    	using SQLiteConnection =  Mono.Data.Sqlite.SqliteConnection;
	    using SQLiteException =   Mono.Data.Sqlite.SqliteException;
    	using SQLiteParameter =   Mono.Data.Sqlite.SqliteParameter;
	    using SQLiteTransaction = Mono.Data.Sqlite.SqliteTransaction;
    #else
    	using System.Data.SQLite;
    #endif
