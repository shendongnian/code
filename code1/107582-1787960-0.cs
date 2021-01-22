    RuleFor(f => f.Names).Must((f, d) =>
                {
                    for (int i = 0; i < d.Count; i++)
                    {
                        if ((String.IsNullOrEmpty(d[i]) &&
                             !String.IsNullOrEmpty(f.URLs[i])))
                            return false;
                    }
    
                    return true;
                })
                .WithMessage("Names cannot be empty.");
    
                RuleFor(f => f.URLs).Must((f, u) =>
                {
                    for (int i = 0; i < u.Count; i++)
                    {
                        if ((String.IsNullOrEmpty(u[i]) &&
                             !String.IsNullOrEmpty(f.Names[i])))
                            return false;
                    }
    
                    return true;
                })
                .WithMessage("URLs cannot be empty.");
