    .method public hidebysig instance class [mscorlib]System.Collections.Generic.List`1<class FeatureCrowd.DomainModel.FeatureModel> FindAll() cil managed
    {
        .maxstack 5
        .locals init (
            [0] string key,
            [1] class [mscorlib]System.Collections.Generic.List`1<class FeatureCrowd.DomainModel.FeatureModel> 'value',
            [2] class [System.Data.Entity]System.Data.Objects.ObjectSet`1<class FeatureCrowd.DomainModel.Feature> query,
            [3] class [mscorlib]System.Func`2<class FeatureCrowd.DomainModel.Feature, class FeatureCrowd.DomainModel.FeatureModel> policy,
            [4] class [mscorlib]System.Func`2<class FeatureCrowd.DomainModel.FeatureModel, string> CS$<>9__CachedAnonymousMethodDelegate6,
            [5] class [mscorlib]System.Collections.Generic.List`1<class FeatureCrowd.DomainModel.FeatureModel> CS$<>9__CachedAnonymousMethodDelegate7,
            [6] bool CS$1$0000,
            [7] char CS$4$0001)
        ...
        L_009f: newobj instance void [mscorlib]System.Collections.Generic.List`1<class FeatureCrowd.DomainModel.FeatureModel>::.ctor()
        L_00a4: stloc.1 
        L_00a5: ldloc.1 
        L_00a6: stloc.s CS$1$0000
        L_00a8: br.s L_00aa
        L_00aa: ldloc.s CS$1$0000
        L_00ac: ret 
    }
