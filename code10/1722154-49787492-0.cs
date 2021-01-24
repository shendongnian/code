    var query = oaPtDbContext.TableChlSyncLog.GroupJoin(
                                  oaPtDbContext.TableMealChl,
                                  chlsynclog => new
                                     {
                                        X1 = chlsynclog.Mealid,
                                        Y1 = chlsynclog.Chid
                                     },
                                  mealchl => new
                                     {
                                        X1 = mealchl.Mealid,
                                        Y1 = mealchl.Chid
                                     },
                                  (chlsynclog, mealchlGroup) => new
                                     {
                                        chlsynclog,
                                        mealchlGroup
                                     })
                               .SelectMany(
                                  @t => mealchlGroup.DefaultIfEmpty(),
                                  (@t, mealchlGroupItem) => new
                                     {
                                        @t,
                                        mealchlGroupItem
                                     })
                               .GroupJoin(
                                  oaPtDbContext.TableService,
                                  @t => mealchlGroupItem.Sid,
                                  service => service.Sid,
                                  (@t, serviceGroup) => new
                                     {
                                        @t,
                                        serviceGroup
                                     })
                               .SelectMany(
                                  @t => serviceGroup.DefaultIfEmpty(),
                                  (@t, serviceGroupItem) => new
                                     {
                                        @t,
                                        serviceGroupItem
                                     })
                               .GroupJoin(
                                  oaPtDbContext.TableChannel,
                                  @t => chlsynclog.Chid,
                                  channel => channel.Chid,
                                  (@t, channelGroup) => new
                                     {
                                        @t,
                                        channelGroup
                                     })
                               .SelectMany(
                                  @t => channelGroup.DefaultIfEmpty(),
                                  (@t, channelGroupItem) => new
                                     {
                                        @t,
                                        channelGroupItem
                                     })
                               .GroupJoin(
                                  oaPtDbContext.TableArea,
                                  @t => chlsynclog.Areaid,
                                  area => area.Areaid,
                                  (@t, areaGroup) => new
                                     {
                                        @t,
                                        areaGroup
                                     })
                               .SelectMany(
                                  @t => areaGroup.DefaultIfEmpty(),
                                  (@t, areaGroupItem) => new
                                     {
                                        chlsynclog.Id,
                                        chlsynclog.Handset,
                                        mealchlGroupItem.Mealname,
                                        areaGroupItem.Proname,
                                        areaGroupItem.Cityname,
                                        chlsynclogType = GetChlsynclogType(chlsynclog.Type),
                                        statusName = GetStatusName(chlsynclog.Statusid),
                                        channelGroupItem.Chname,
                                        syncTime = chlsynclog.Synctime.ToString("yyyy-MM-dd HH:mm:ss")
                                     });
