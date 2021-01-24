protected override void OnModelCreating (ModelBuilder modelBuilder)
{
	var StringListToStringConverter = new ValueConverter<ICollection<string>, string>(_strings => string.Join(";", _strings), _string => _string.Split(new[] { ';' }));
	var IntListToStringConverter = new ValueConverter<ICollection<int>, string>(_ints => string.Join(";", _ints), _string => Array.ConvertAll(_string.Split(new[] { ';' }), int.Parse));
	var AccessTokenToStringConverter = new ValueConverter<ICollection<AccessToken>, string>(_token => JsonConvert.SerializeObject(_token), _string => JsonConvert.DeserializeObject<ICollection<AccessToken>>(_string));
	var ProfileToStringConverter = new ValueConverter<Profile, string>(_token => JsonConvert.SerializeObject(_token), _string => JsonConvert.DeserializeObject<Profile>(_string));
	modelBuilder
		.Entity<UserModel>()
		.Property(e => e.Permissions)
		.HasConversion(IntListToStringConverter);
	modelBuilder
		.Entity<UserModel>()
		.Property(e => e.AccessTokens)
		.HasConversion(AccessTokenToStringConverter);
	modelBuilder
		.Entity<UserModel>()
		.Property(e => e.Profile)
		.HasConversion(ProfileToStringConverter);
	modelBuilder
		.Entity<ClientModel>()
		.Property(e => e.Categories)
		.HasConversion(StringListToStringConverter);
}
I think that converting properties unto string and store them in the same table is better than saving each property into new table.
