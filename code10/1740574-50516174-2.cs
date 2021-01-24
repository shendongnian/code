        public void Configure(IApplicationBuilder app, AppDbContext dbContext)
        {
            SeedData(dbContext);
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
        private void SeedData(AppDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
            Language english = new Language
            {
                IsActive = true,
                IsPrimary = true,
                Country = "United States",
                Code = "en-US"
            };
            Language traditionalChinese = new Language
            {
                IsActive = true,
                IsPrimary = false,
                Country = "Chinese (Taiwan)",
                Code = "zh-TW"
            };
            Language simplifedChinese = new Language
            {
                IsActive = true,
                IsPrimary = false,
                Country = "Chinese (People's Republic of China)",
                Code = "zh-CN"
            };
            Language korean = new Language
            {
                IsActive = true,
                IsPrimary = false,
                Country = "Korea",
                Code = "ko-KR"
            };
            Language japanese = new Language
            {
                IsActive = true,
                IsPrimary = false,
                Country = "Japan",
                Code = "ja-JP"
            };
            Category guitar = new Category
            {
                Value = 1,
                AutoTranslate = true,
                Translations = new List<CategoryTranslation>
                {
                    new CategoryTranslation
                    {
                        Name = "Guitars",
                        Language = english,
                        PrimaryTranslation = true
                    },
                    new CategoryTranslation
                    {
                        Name = "吉他",
                        Language = traditionalChinese,
                        PrimaryTranslation = false
                    },
                    new CategoryTranslation
                    {
                        Name = "吉他",
                        Language = simplifedChinese,
                        PrimaryTranslation = false
                    },
                    new CategoryTranslation
                    {
                        Name = "기타",
                        Language = korean,
                        PrimaryTranslation = false
                    },
                    new CategoryTranslation
                    {
                        Name = "ギター",
                        Language = japanese,
                        PrimaryTranslation = false
                    }
                }
            };
            Category bass = new Category
            {
                Value = 2,
                AutoTranslate = true,
                Translations = new List<CategoryTranslation>
                {
                    new CategoryTranslation
                    {
                        Name = "Bass",
                        Language = english,
                        PrimaryTranslation = true
                    },
                    new CategoryTranslation
                    {
                        Name = "低音吉他",
                        Language = traditionalChinese,
                        PrimaryTranslation = false
                    },
                    new CategoryTranslation
                    {
                        Name = "低音吉他",
                        Language = simplifedChinese,
                        PrimaryTranslation = false
                    }
                }
            };
            dbContext.Categories.AddRange(guitar, bass);
            dbContext.Languages.AddRange(english, traditionalChinese,
                simplifedChinese, korean, japanese);
            dbContext.SaveChanges();
        }
