    public static void Seed(IServiceProvider applicationBuilder)
            {
                AppDbContext context =
                    applicationBuilder.GetRequiredService<AppDbContext>();﻿
            }
