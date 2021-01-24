    public void SaveObject(Monster monster)
    {
        SQLiteConnection sqliteConnection = new SQLiteConnection(ConnectionString.Connection);
        sqliteConnection.Open();
        String query = String.Empty;
        List<SQLiteParameter> parameters = new List<SQLiteParameter>()
        {
            new SQLiteParameter("@Name", monster.Name)
            //new SQLiteParameter("@Size", monster.Size),
            //new SQLiteParameter("@Type", monster.Type),
            //new SQLiteParameter("@Subtype", monster.Subtype),
            //new SQLiteParameter("@Alignment", monster.Alignment),
            //new SQLiteParameter("@ArmorClass", monster.ArmorClass),
            //new SQLiteParameter("@HitPoints", monster.HitPoints),
            //new SQLiteParameter("@HitDice", monster.HitDice),
            //new SQLiteParameter("@Speed", monster.Speed),
            //new SQLiteParameter("@DamageVulnerabilities", monster.DamageVulnerabilities),
            //new SQLiteParameter("@DamageResistances", monster.DamageResistances),
            //new SQLiteParameter("@DamageImmunities", monster.DamageImmunities),
            //new SQLiteParameter("@ConditionImmunities", monster.ConditionImmunities),
            //new SQLiteParameter("@Senses", monster.Senses),
            //new SQLiteParameter("@Languages", monster.Languages),
            //new SQLiteParameter("@ChallengeRating", monster.ChallengeRating)
        };
        switch (monster.InternalState)
        {
            case InternalStates.New:
                query = @"  INSERT INTO Monsters(Id,
                                                Name,
                                                Size,
                                                Type,
                                                Subtype,
                                                Alignment,
                                                ArmorClass,
                                                HitPoints,
                                                HitDice,
                                                Speed,
                                                DamageVulnerabilities,
                                                DamageResistances,
                                                DamageImmunities,
                                                ConditionImmunities,
                                                Senses,
                                                Languages,
                                                ChallengeRating) 
                            VALUES (@Id,
                                    @Name,
                                    @Size,
                                    @Type,
                                    @Subtype,
                                    @Alignment,       
                                    @ArmorClass,
                                    @HitPoints,
                                    @HitDice,
                                    @Speed,
                                    @DamageVulnerabilities,
                                    @DamageResistances,
                                    @DamageImmunities,
                                    @ConditionImmunities,
                                    @Senses,
                                    @Languages,
                                    @ChallengeRating)";
                    parameters.Add(new SQLiteParameter("@Id", monster.Id ));
                break;
            case InternalStates.Modified:
                query = @"  UPDATE Monsters
                            SET Name = @Name
                            WHERE Monsters.Id like @Id";
                //Size = @Size,
                //                Type = @Type,
                //                Subtype = @Subtype,
                //                Alignment = @Alignment,
                //                ArmorClass = @ArmorClass,
                //                HitPoints = @HitPoints,
                //                HitDice = @HitDice,
                //                Speed = @Speed,
                //                DamageVulnerabilities = @DamageVulnerabilities,
                //                DamageResistances = @DamageResistances,
                //                DamageImmunities = @DamageImmunities,
                //                ConditionImmunities = @ConditionImmunities,
                //                Senses = @Senses,
                //                Languages = @Languages,
                //                ChallengeRating = @ChallengeRating
                parameters.Add(new SQLiteParameter("@Id", "%" + monster.Id + "%"));
                break;
            case InternalStates.Deleted:
                //To maybe implement in the future
                break;
        }
        SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
        command.Parameters.AddRange(parameters.ToArray());
        int i = command.ExecuteNonQuery();
        monster.SetInternalState(InternalStates.UnModified, true);
        sqliteConnection.Close();
    }
