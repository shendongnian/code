    Namespace TestingRoutines.Collections
    
    
        ''' <summary>
        ''' A testing routine which compares the state of a tested dictionary (not trusted) against the state of control dictionary (trusted), after applying the same operations to both.
        ''' </summary>
        ''' <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        ''' <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        Public Class Testing_IDictionary(Of TKey, TValue)
    
            ''' <summary>
            ''' The trusted dictionary implementation to verify the tests against.
            ''' </summary>
            Public ReadOnly Property ControlDict As IDictionary(Of TKey, TValue)
    
            ''' <summary>
            ''' The non-trusted dictionary implementation to be tested.
            ''' </summary>
            Public ReadOnly Property TestedDict As IDictionary(Of TKey, TValue)
    
            ''' <summary>
            ''' Exoses a set of generic tests.
            ''' </summary>
            Private ReadOnly Property GenericTests As New GenericTests(Of IDictionary(Of TKey, TValue))
    
    
            Private Sub New()
            End Sub
    
            ''' <summary>
            ''' Creates a new instance of a testing routine which compares the state of a tested dictionary (not trusted) against the state of control dictionary (trusted), after applying the same operations to both.
            ''' </summary>
            ''' <param name="ControlDict">The trusted dictionary implementation to verify the tests against.</param>
            ''' <param name="TestedDict">The non-trusted dictionary implementation to be tested.</param>
            Public Sub New(ControlDict As IDictionary(Of TKey, TValue), TestedDict As IDictionary(Of TKey, TValue))
                Me.ControlDict = ControlDict
                Me.TestedDict = TestedDict
            End Sub
    
    
            ''' <summary>
            ''' Runs the complete set of tests available in the testing routine.
            ''' </summary>
            ''' <param name="SomeKeys">The keys of some items to be added in the dictionary. Minimum 6 items; all keys must be unique.</param>
            ''' <param name="SomeValues">The values of some items to be added in the dictionary. There must be as many values as item keys.</param>
            ''' <param name="OtherKeys">The keys of some items which are different from the items to be added in the dictionary. Minimum 6 items; all keys must be unique.</param>
            ''' <param name="OtherValues">The values of some items which are different from the items to be added in the dictionary. there must be as many values as item keys</param>
            Public Sub TestFullBatch(SomeKeys As IEnumerable(Of TKey), SomeValues As IEnumerable(Of TValue), OtherKeys As IEnumerable(Of TKey), OtherValues As IEnumerable(Of TValue))
    
                Dim MinAddCount As Integer = 6
                If SomeKeys.Count < MinAddCount Then Throw New ArgumentException($"This test requires at least {MinAddCount} item keys to be added.", NameOf(SomeKeys))
                If SomeKeys.Count <> SomeValues.Count Then Throw New ArgumentException("There must be as many item values as item keys to be added.", NameOf(SomeValues))
                If SomeKeys.Any(Function(p) SomeKeys.Count(Function(q) p.Equals(q)) > 1) Then Throw New ArgumentException("The collection of item keys to be added cannot contain duplicates.", NameOf(SomeKeys))
    
                Dim MinNotAddedCount As Integer = 6
                If OtherKeys.Count < MinNotAddedCount Then Throw New ArgumentException($"This test requires at least {MinNotAddedCount} item keys to be tested as not added.", NameOf(OtherKeys))
                If OtherKeys.Count <> OtherValues.Count Then Throw New ArgumentException("There must be as many item values as item keys to be tested as not added.", NameOf(OtherValues))
                If OtherKeys.Any(Function(p) OtherKeys.Count(Function(q) p.Equals(q)) > 1) Then Throw New ArgumentException("The collection of item keys to be tested as not added cannot contain duplicates.", NameOf(OtherKeys))
                If OtherKeys.Any(Function(p) SomeKeys.Contains(p)) Then Throw New ArgumentException("The item keys to be tested as not added cannot appear in the list of item keys to be added.", NameOf(OtherKeys))
    
    
                IsReadOnly()
    
                Add(SomeKeys, SomeValues, OtherKeys, OtherValues)
    
                Remove(SomeKeys.Skip(1).Take(2))
                Remove(SomeKeys.Reverse.Take(2))
    
                Clear()
    
                AddItem(SomeKeys, SomeValues, OtherKeys, OtherValues)
    
                RemoveItem(SomeKeys.Take(2), SomeValues.Take(2))
                RemoveItem(SomeKeys.Reverse.Skip(2).Take(2), SomeValues.Reverse.Skip(2).Take(2))
    
                Dim ArrayKeys As IEnumerable(Of TKey) = OtherKeys.Take(MinNotAddedCount - 2).ToArray
                Dim ArrayValues As IEnumerable(Of TValue) = OtherValues.Take(MinNotAddedCount - 2).ToArray
                CopyTo(ArrayKeys, ArrayValues, MinNotAddedCount - 4)
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the IsReadOnly property.
            ''' </summary>
            Public Sub IsReadOnly()
    
                Assert.AreEqual(Me.TestedDict.IsReadOnly, Me.ControlDict.IsReadOnly)
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the Add(Key, Value) method.
            ''' </summary>
            ''' <param name="AddKeys">The item keys to add.</param>
            ''' <param name="AddValues">The item values to add.</param>
            ''' <param name="NotAddedKeys">The item keys which are expected not be included in the dictionary.</param>
            ''' <param name="NotAddedValues">The item values which are expected not to be included in the dictionary.</param>
            Public Sub Add(AddKeys As IEnumerable(Of TKey), AddValues As IEnumerable(Of TValue), NotAddedKeys As IEnumerable(Of TKey), NotAddedValues As IEnumerable(Of TValue))
    
                Dim MyKeyEnum As IEnumerator(Of TKey) = AddKeys.GetEnumerator
                Dim MyValueEnum As IEnumerator(Of TValue) = AddValues.GetEnumerator
    
                Do While MyKeyEnum.MoveNext And MyValueEnum.MoveNext
                    Dim MyKey As TKey = MyKeyEnum.Current
                    Dim MyValue As TValue = MyValueEnum.Current
                    Me.ControlDict.Add(MyKey, MyValue)
                    Me.TestedDict.Add(MyKey, MyValue)
                Loop
    
                TestBasicContents()
    
                TestItem(AddKeys.First, AddValues.First)
                TestItem(AddKeys.Last, AddValues.Last)
                TestItem(NotAddedKeys.First, NotAddedValues.First)
                TestItem(NotAddedKeys.Last, NotAddedValues.Last)
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the Add(KeyValuePair) method.
            ''' </summary>
            ''' <param name="AddKeys">The item keys to add.</param>
            ''' <param name="AddValues">The item values to add.</param>
            ''' <param name="NotAddedKeys">The item keys which are expected not to be included in the dictionary.</param>
            ''' <param name="NotAddedValues">The item values which are expected not to be included in the dictionary.</param>
            Public Sub AddItem(AddKeys As IEnumerable(Of TKey), AddValues As IEnumerable(Of TValue), NotAddedKeys As IEnumerable(Of TKey), NotAddedValues As IEnumerable(Of TValue))
    
                Dim MyKeyEnum As IEnumerator(Of TKey) = AddKeys.GetEnumerator
                Dim MyValueEnum As IEnumerator(Of TValue) = AddValues.GetEnumerator
                Do While MyKeyEnum.MoveNext And MyValueEnum.MoveNext
                    Dim MyKey As TKey = MyKeyEnum.Current
                    Dim MyValue As TValue = MyValueEnum.Current
                    Dim KeyValue As New KeyValuePair(Of TKey, TValue)(MyKey, MyValue)
                    Me.ControlDict.Add(KeyValue)
                    Me.TestedDict.Add(KeyValue)
                Loop
    
                TestBasicContents()
    
                TestItem(AddKeys.First, AddValues.First)
                TestItem(AddKeys.Last, AddValues.Last)
                TestItem(NotAddedKeys.First, NotAddedValues.First)
                TestItem(NotAddedKeys.Last, NotAddedValues.Last)
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the Remove(Key) method.
            ''' </summary>
            ''' <param name="RemoveKeys">The item keys of the items to remove.</param>
            Public Sub Remove(RemoveKeys As IEnumerable(Of TKey))
    
                For Each MyKey As TKey In RemoveKeys
                    Me.ControlDict.Remove(MyKey)
                    Me.TestedDict.Remove(MyKey)
                Next
    
                TestBasicContents()
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the Remove(KeyValuePair) method.
            ''' </summary>
            ''' <param name="RemoveKeys">The item keys to remove.</param>
            ''' <param name="RemoveValues">The item values to remove.</param>
            Public Sub RemoveItem(RemoveKeys As IEnumerable(Of TKey), RemoveValues As IEnumerable(Of TValue))
    
                Dim MyKeyEnum As IEnumerator(Of TKey) = RemoveKeys.GetEnumerator
                Dim MyValueEnum As IEnumerator(Of TValue) = RemoveValues.GetEnumerator
    
                Do While MyKeyEnum.MoveNext And MyValueEnum.MoveNext
                    Dim MyKey As TKey = MyKeyEnum.Current
                    Dim MyValue As TValue = MyValueEnum.Current
                    Dim KeyValue As New KeyValuePair(Of TKey, TValue)(MyKey, MyValue)
                    Me.ControlDict.Remove(KeyValue)
                    Me.TestedDict.Remove(KeyValue)
                Loop
    
                TestBasicContents()
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the Clear() method.
            ''' </summary>
            Public Sub Clear()
    
                Me.ControlDict.Clear()
                Me.TestedDict.Clear()
    
                TestBasicContents()
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies the CopyTo(array(), arrayIndex) method.
            ''' </summary>
            ''' <param name="ArrayKeys">The collection of item keys to include in the list of KeyValuePairs to copy from..</param>
            ''' <param name="ArrayValues">The collection of item values to include in the list of KeyValuePairs to copy from.</param>
            ''' <param name="ArrayIndex">The zero-based array index at which copying will begin.</param>
            Public Sub CopyTo(ArrayKeys As IEnumerable(Of TKey), ArrayValues As IEnumerable(Of TValue), ArrayIndex As Integer)
    
                Dim MyCollection As New List(Of KeyValuePair(Of TKey, TValue))
    
                Dim MyKeyEnum As IEnumerator(Of TKey) = ArrayKeys.GetEnumerator
                Dim MyValueEnum As IEnumerator(Of TValue) = ArrayValues.GetEnumerator
                Do While MyKeyEnum.MoveNext And MyValueEnum.MoveNext
                    Dim MyKey As TKey = MyKeyEnum.Current
                    Dim MyValue As TValue = MyValueEnum.Current
                    Dim KeyValue As New KeyValuePair(Of TKey, TValue)(MyKey, MyValue)
                    MyCollection.Add(KeyValue)
                Loop
    
                Dim MyControlArray(99) As KeyValuePair(Of TKey, TValue) ' <- Note: Fixed size array
                Dim MyTestingArray(99) As KeyValuePair(Of TKey, TValue) ' <- Note: Fixed size array
                MyCollection.CopyTo(MyControlArray, 0)
                MyCollection.CopyTo(MyTestingArray, 0)
    
                Me.ControlDict.CopyTo(MyControlArray, ArrayIndex)
                Me.TestedDict.CopyTo(MyTestingArray, ArrayIndex)
    
                CollectionAssert.AreEqual(MyControlArray, MyTestingArray)
    
            End Sub
    
    
    #Region "Helpers"
    
    
            ''' <summary>
            ''' Verifies state equality of the control and tested dictionaries. This is achieved by comparing the Count, Keys, and Values properties.
            ''' </summary>
            Private Sub TestBasicContents()
    
                Assert.AreEqual(Me.ControlDict.Count, Me.TestedDict.Count)
                CollectionAssert.AreEqual(Me.ControlDict.Keys.ToList, Me.TestedDict.Keys.ToList)
                CollectionAssert.AreEqual(Me.ControlDict.Values.ToList, Me.TestedDict.Values.ToList)
    
            End Sub
    
    
            ''' <summary>
            ''' Verifies behaviour equality of the control and tested dictionaries, for a given item. This is achieved by comparing the ContainsKey(Key), Contains(KeyValuePair), TryGetValue(Key, Value)
            ''' </summary>
            ''' <param name="Key">The key of the item to look for.</param>
            ''' <param name="Value">The value of the item to look for.</param>
            Private Sub TestItem(Key As TKey, Value As TValue)
    
                Dim KeyValue As New KeyValuePair(Of TKey, TValue)(Key, Value)
    
                Assert.AreEqual(Me.ControlDict.ContainsKey(Key), Me.TestedDict.ContainsKey(Key))
                Assert.AreEqual(Me.ControlDict.Contains(KeyValue), Me.TestedDict.Contains(KeyValue))
    
                Dim MyControlVal As TValue
                Dim MyTestingVal As TValue
                Assert.AreEqual(Me.ControlDict.TryGetValue(Key, MyControlVal), Me.TestedDict.TryGetValue(Key, MyTestingVal))
                Assert.AreEqual(MyControlVal, MyTestingVal)
    
                GenericTests.TestExceptionBehaviour(Me.ControlDict, Me.TestedDict, Function(p) p.Item(Key))
                GenericTests.TestExceptionBehaviour(Me.ControlDict, Me.TestedDict, Sub(p) p.Item(Key) = Value)
                GenericTests.TestExceptionBehaviour(Me.ControlDict, Me.TestedDict, Sub(p) p.Add(Key, Value))
                GenericTests.TestExceptionBehaviour(Me.ControlDict, Me.TestedDict, Sub(p) p.Add(KeyValue))
                GenericTests.TestExceptionBehaviour(Me.ControlDict, Me.TestedDict, Function(p) p.Remove(Key))
                GenericTests.TestExceptionBehaviour(Me.ControlDict, Me.TestedDict, Function(p) p.Remove(KeyValue))
    
            End Sub
    
    
    #End Region
    
    
        End Class
    
    
    End Namespace
