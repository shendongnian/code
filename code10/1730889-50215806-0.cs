     var projBlk = projContext.LoadQuery(
                            projContext.Projects
                            .Where(p =>
                                p.Id == id
                            )
                            .Include(p => p.Id,
                            p => p.ProjectSiteUrl, // Moved ProjectSiteUrl as second loading parameter.
                            p => p.Tasks,
                            p => p.TaskLinks,
                            p => p.ScheduledFromStart,
                            
                                p => p.Name,
                                p => p.IncludeCustomFields,
                                p => p.IncludeCustomFields.CustomFields,
                                P => P.IncludeCustomFields.CustomFields.IncludeWithDefaultProperties(
                                    lu => lu.LookupTable,
                                    lu => lu.LookupEntries,
                                    lu => lu.LookupEntries.IncludeWithDefaultProperties(
                                        entry => entry.FullValue,
                                        entry => entry.InternalName)
                                )
                            )
                        );
