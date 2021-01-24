            var stars = "112131121311213112131121311213";
            string base36Result = ConvertToOtherBase(stars, 4, 36);
            // 32NSB7MBR9T3
            string base4Result = ConvertToOtherBase(base36Result, 36, 4);
            // 112131121311213112131121311213
