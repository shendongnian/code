    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using NUnit.Framework;
    using MediaBrowser.Library.Persistance;
    
    namespace TestMediaBrowser.Unit {
        [TestFixture]
        public class TestXmlSettings {
    
            enum Farts { 
                Smelly, 
                SilentButDeadly
            }
    
            class Monster {
                public Weapon Weapon; 
            }
    
            class Weapon {
                public int LaserCount { get; set; }
            }
    
            class Farter {
                public Farts Smell = Farts.Smelly;
            }
    
            class Group {
                public List<Person> People;
            }
    
            class Person {
                public int Age = 1; 
                public string Name = "Default";
                public bool Happy = true;
                public DateTime Birthdate = DateTime.Now;  
            }
    
            class Account {
                public Person Person;
                public int Balance;
            }
    
            const string CONFIG_FILE = "test.config";
    
            private void ClearConfig() {
                if (File.Exists(CONFIG_FILE)) {
                    File.Delete(CONFIG_FILE);
                }
            }
    
            public void TestProperty() {
                ClearConfig();
                Monster monster = new Monster();
                XmlSettings<Monster> settings = XmlSettings<Monster>.Bind(monster, CONFIG_FILE);
                monster.Weapon = new Weapon();
                monster.Weapon.LaserCount = 99;
                settings.Write();
    
                monster = new Monster();
                settings = XmlSettings<Monster>.Bind(monster, CONFIG_FILE);
    
                Assert.AreEqual(monster.Weapon.LaserCount, 99);
            } 
    
            public void TestEnum() {
                ClearConfig();
                Farter farter = new Farter();
                XmlSettings<Farter> settings = XmlSettings<Farter>.Bind(farter, CONFIG_FILE);
                farter.Smell = Farts.SilentButDeadly;
                settings.Write();
    
                farter = new Farter();
                settings = XmlSettings<Farter>.Bind(farter, CONFIG_FILE);
    
                Assert.AreEqual(farter.Smell, Farts.SilentButDeadly);
            } 
    
            [Test]
            public void TestList() {
                ClearConfig();
                Group group = new Group();
                group.People = new List<Person>();
                group.People.Add(new Person());
                group.People.Add(new Person());
                XmlSettings<Group> settings = XmlSettings<Group>.Bind(group, CONFIG_FILE);
                settings.Write();
    
                group = new Group();
                settings = XmlSettings<Group>.Bind(group, CONFIG_FILE);
    
                Assert.AreEqual(group.People.Count, 2);
    
            }
    
            [Test]
            public void BasicValueTypeTest() {
                ClearConfig();
                var person = new Person();
                XmlSettings<Person> settings = XmlSettings<Person>.Bind(person, CONFIG_FILE);
                person.Age = 3;
                person.Name = "Sam";
                person.Happy = false;
                person.Birthdate = DateTime.Today;
                settings.Write();
    
                person = new Person();
                settings = XmlSettings<Person>.Bind(person, CONFIG_FILE);
    
                Assert.AreEqual(person.Age, 3);
                Assert.AreEqual(person.Name, "Sam");
                Assert.AreEqual(person.Happy, false);
                Assert.AreEqual(person.Birthdate, DateTime.Today);
            }
    
            [Test]
            public void NestedObjectTypeTest() {
                ClearConfig();
                var account = new Account();
                var settings = XmlSettings<Account>.Bind(account, CONFIG_FILE);
                var person = new Person();
                person.Age = 3;
                person.Name = "Sam";
                person.Happy = false;
                person.Birthdate = DateTime.Today;
    
                account.Person = person;
                account.Balance = 999;
    
                settings.Write();
    
                account = new Account();
                settings = XmlSettings<Account>.Bind(account, CONFIG_FILE);
    
    
                person = account.Person;
                Assert.AreEqual(account.Balance, 999);
                Assert.AreEqual(person.Age, 3);
                Assert.AreEqual(person.Name, "Sam"); 
                Assert.AreEqual(person.Happy, false); 
                Assert.AreEqual(person.Birthdate, DateTime.Today); 
            }
        }
    }
