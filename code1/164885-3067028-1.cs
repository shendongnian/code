            int versionNo = template.RenderingTemplateVersionList.Select(v => v.VersionName.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).ElementAt(1))
                                                                 .Catch(EnumerableEx.Return<string>(int.MinValue.ToString(CultureInfo.InvariantCulture)))
                                                                 .Let(vl => 
                                                                            vl.Any(v => v == int.MinValue.ToString(CultureInfo.InvariantCulture)) ? 
                                                                            EnumerableEx.Return<string>(int.MinValue.ToString(CultureInfo.InvariantCulture)) : vl
                                                                     )
                                                                 .Select(v => Convert.ToInt32(v))
                                                                 .Catch(EnumerableEx.Return<int>(int.MinValue))
                                                                 .Let(vl => vl.Any(v => v == int.MinValue)? EnumerableEx.Return<int>(int.MinValue) : vl)
                                                                 .OrderByDescending(v => v)
                                                                 .DefaultIfEmpty(0)
                                                                 .FirstOrDefault();
            if (versionNo == int.MinValue)
            {
                // Error in VersionName Format
            }
            else
            {
                if (versionNo > 0)
                {
                    int newVersionNo = versionNo++;
                }
                else
                { 
                    // There is no current version available
                }
            }
