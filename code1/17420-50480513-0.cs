        public static string SpaceCapitals(this string arg) =>
           new string(arg.Aggregate(new List<Char>(),
                          (accum, x) => 
                          {
                              if (Char.IsUpper(x) &&
                                  accum.Any() &&
                                  // prevent double spacing
                                  accum.Last() != ' ' &&
                                  // prevent spacing acronyms (ASCII, SCSI)
                                  !Char.IsUpper(accum.Last()))
                              {
                                  accum.Add(' ');
                              }
                              accum.Add(x);
                              return accum;
                          }).ToArray());
