    public class ModelsTest {
        [TestMethod]
        public void TestMethod1() {
            DbEntities db = new DbEntities();
            using (PermissionDataBase permissionDb = new PermissionDataBase(db)) {
                Permission newEntity = new Permission() {
                    Name = "Test1"
                };
                permissionDb.Add(newEntity);
                Assert.IsTrue(newEntity.Id > 0);
            }
        }
        [TestMethod]
        public void TestMethod2() {
            DbEntities db = new DbEntities();
            using (PermissionDataBase permissionDb = new PermissionDataBase(db)) {
                List<Permission> items = permissionDb.GetAll();
                Assert.IsTrue(items.Count > 0);
            }
        }
        [TestMethod]
        public void TestMethod3() {
            DbEntities db = new DbEntities();
            using (PermissionDataBase permissionDb = new PermissionDataBase(db)) {
                Permission toDelete = permissionDb.Get(3);  //Assuming id=3 exists
                permissionDb.Delete(toDelete);
                Permission deleted = permissionDb.Get(3);
                Assert.IsNull(deleted);
            }
        }
    }
