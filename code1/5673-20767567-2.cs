    .Lambda #Lambda1<System.Func`4[System.Collections.Generic.List`1[System.Int32],CloneExtensions.CloningFlags,System.Collections.Generic.IDictionary`2[System.Type,System.Func`2[System.Object,System.Object]],System.Collections.Generic.List`1[System.Int32]]>(
        System.Collections.Generic.List`1[System.Int32] $source,
        CloneExtensions.CloningFlags $flags,
        System.Collections.Generic.IDictionary`2[System.Type,System.Func`2[System.Object,System.Object]] $initializers) {
        .Block(System.Collections.Generic.List`1[System.Int32] $target) {
            .If ($source == null) {
                .Return #Label1 { null }
            } .Else {
                .Default(System.Void)
            };
            .If (
                .Call $initializers.ContainsKey(.Constant<System.Type>(System.Collections.Generic.List`1[System.Int32]))
            ) {
                $target = (System.Collections.Generic.List`1[System.Int32]).Call ($initializers.Item[.Constant<System.Type>(System.Collections.Generic.List`1[System.Int32])]
                ).Invoke((System.Object)$source)
            } .Else {
                $target = .New System.Collections.Generic.List`1[System.Int32]()
            };
            .If (
                ((System.Byte)$flags & (System.Byte).Constant<CloneExtensions.CloningFlags>(Fields)) == (System.Byte).Constant<CloneExtensions.CloningFlags>(Fields)
            ) {
                .Default(System.Void)
            } .Else {
                .Default(System.Void)
            };
            .If (
                ((System.Byte)$flags & (System.Byte).Constant<CloneExtensions.CloningFlags>(Properties)) == (System.Byte).Constant<CloneExtensions.CloningFlags>(Properties)
            ) {
                .Block() {
                    $target.Capacity = .Call CloneExtensions.CloneFactory.GetClone(
                        $source.Capacity,
                        $flags,
                        $initializers)
                }
            } .Else {
                .Default(System.Void)
            };
            .If (
                ((System.Byte)$flags & (System.Byte).Constant<CloneExtensions.CloningFlags>(CollectionItems)) == (System.Byte).Constant<CloneExtensions.CloningFlags>(CollectionItems)
            ) {
                .Block(
                    System.Collections.Generic.IEnumerator`1[System.Int32] $var1,
                    System.Collections.Generic.ICollection`1[System.Int32] $var2) {
                    $var1 = (System.Collections.Generic.IEnumerator`1[System.Int32]).Call $source.GetEnumerator();
                    $var2 = (System.Collections.Generic.ICollection`1[System.Int32])$target;
                    .Loop  {
                        .If (.Call $var1.MoveNext() != False) {
                            .Call $var2.Add(.Call CloneExtensions.CloneFactory.GetClone(
                                    $var1.Current,
                                    $flags,
       
                             $initializers))
                    } .Else {
                        .Break #Label2 { }
                    }
                }
                .LabelTarget #Label2:
            }
        } .Else {
            .Default(System.Void)
        };
        .Label
            $target
        .LabelTarget #Label1:
    }
