    Control bobParent = bob.Parent;
    Control aliceParent = alice.Parent;
    int bobIndex = bobParent.Controls.GetChildIndex(bob);
    int aliceIndex = aliceParent.Controls.GetChildIndex(alice);
    bobParent.Controls.Add(alice);
    aliceParent.Controls.Add(bob);
    bobParent.Controls.SetChildIndex(alice, bobIndex);
    aliceParent.Controls.SetChildIndex(bob, aliceIndex);
