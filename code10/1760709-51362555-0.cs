    ManyToOne(we => we.Application, mto => { mto.Column("application_id")
                                             mto.Class(typeof(Application));
                                             mto.Update(false);
                                             mto.Insert(false);
                                             mto.Lazy(LazyRelation.NoLazy);
      });
